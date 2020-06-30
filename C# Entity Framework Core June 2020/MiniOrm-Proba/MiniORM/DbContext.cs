using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;


namespace MiniORM
{
    public abstract class DbContext
    {
        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }
        }

        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime),
        };

        public void SaveChanges()
        {
            object[] dbSets = this.dbSetProperties
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(entity => !IsObjestValid(entity))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(this.connection))
            {
                using (SqlTransaction transaction = this.connection.StartTransaction())
                {
                    foreach (IEnumerable dbSet in dbSets)
                    {
                        Type dbSeType = dbSet
                            .GetType()
                            .GetGenericArguments()
                            .First();

                        MethodInfo persisteMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSeType);

                        try
                        {
                            persisteMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        private static bool IsObjestValid(object e)
        {
            ValidationContext validationContext = new ValidationContext(e);

            List<ValidationResult> validationErrors = new List<ValidationResult>();

            bool validationResult = Validator.TryValidateObject(e, validationContext, validationErrors);

            return validationResult;
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
        {
            string tableName = this.GetTableName(typeof(TEntity));

            string[] columns = this.connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            TEntity[] modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private void InitializeDbSets()
        {
            foreach (var dbSet in dbSetProperties)
            {
                Type dbSeType = dbSet.Key;
                PropertyInfo dbSetProperty = dbSet.Value;

                MethodInfo populatemethod = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSeType);

                populatemethod.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet) where TEntity : class, new()
        {
            IEnumerable<TEntity> entities = this.LoadTableEntities<TEntity>();

            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(entities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>() where TEntity : class, new()
        {
            Type table = typeof(TEntity);
            string[] colums = GetEntityColumnNames(table);

            string tableName = GetTableName(table);

            TEntity[] fetchedRows = this.connection
                .FetchResultSet<TEntity>(tableName,colums)
                .ToArray();

            return fetchedRows;
        }

        private string[] GetEntityColumnNames(Type table)
        {
            string tableName = GetTableName(table);

            string[] dbColumns = this.connection
                .FetchColumnNames(tableName)
                .ToArray();

            string[] columns = table
                .GetProperties()
                .Where(pi =>
                    dbColumns.Contains(pi.Name) && !pi.HasAttribute<NotMappedAttribute>() &&
                    AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return columns;
        }

        private string GetTableName(Type tableType)
        {
            string tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute)))?.Name;
            if (tableName == null)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName;
        }

        private void MapAllRelations()
        {
            foreach (var dbSetProperty in this.dbSetProperties)
            {
                Type dbSeType = dbSetProperty.Key;

                MethodInfo mapRelationsGenericMethod = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSeType);

                object dbSet = dbSetProperty.Value.GetValue(this);

                mapRelationsGenericMethod.Invoke(this, new object[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            this.MapNavigationProperties(dbSet);

            PropertyInfo[] collections = entityType
                .GetProperties()
                .Where(pi =>
                    pi.PropertyType.IsGenericType &&
                    pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                Type collectionType = collection
                    .PropertyType
                    .GetGenericArguments()
                    .First();

                MethodInfo mapCollectionMethod = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);

                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);

            PropertyInfo[] foreignKeys = entityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                string navigationPropertyname = foreignKey
                    .GetCustomAttribute<ForeignKeyAttribute>().Name;

                PropertyInfo navigationProperty = entityType
                    .GetProperty(navigationPropertyname);

                object navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType]
                    .GetValue(this);

                PropertyInfo navigationPrimaryKey = navigationProperty
                    .PropertyType
                    .GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    object foreignKeyValue = foreignKey.GetValue(entity);

                    object navigationPropertyValue = ((IEnumerable<object>) navigationDbSet)
                        .First(currentNavigationProperty =>
                            navigationPrimaryKey.GetValue(currentNavigationProperty) == foreignKeyValue);
                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new()
            where TCollection : class, new()
        {
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);

            PropertyInfo[] primaryKeys = collectionType
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            PropertyInfo primaryKey = primaryKeys.First();

            PropertyInfo foreignKey = entityType
                .GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            bool isManyToMany = primaryKeys.Length >= 2;

            if (isManyToMany)
            {
                primaryKey = collectionType
                    .GetProperties()
                    .First(pi => collectionType
                        .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                        .PropertyType == entityType);
            }

            DbSet<TCollection> navigationalDbSet = (DbSet<TCollection>)
                this.dbSetProperties[collectionType]
                .GetValue(this);

            foreach (var entity in dbSet)
            {
                object primaryKeyValue = foreignKey.GetValue(entity);

                TCollection[] navigationEntities = navigationalDbSet
                    .Where(navigationEntity => primaryKey
                        .GetValue(navigationEntity).Equals(primaryKeyValue))
                    .ToArray();

                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            var dbSets = this.GetType()
                .GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

            return dbSets;
        }
    }
}