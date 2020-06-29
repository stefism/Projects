using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	public abstract class DbContext
    {
        private readonly DatabaseConnection connection;
        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(decimal), typeof(bool), typeof(DateTime)
        };

        protected DbContext(string connectionString)
        {
            connection = new DatabaseConnection(connectionString);

            dbSetProperties = DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                InitializeDbSets();
            }

            MapAllRelations();
        }

        public void SaveChanges()
        {
            object[] dbSets = dbSetProperties
                .Select(pi => pi.Value.GetValue(this)).ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                object[] invalidEntities = dbSet
                    .Where(entity => !IsObjectValid(entity)).ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(connection))
            {
                using (SqlTransaction transaction = connection.StartTransaction())
                {
                    foreach (IEnumerable dbSet in dbSets)
                    {
                        Type dbSetType = dbSet.GetType().GetGenericArguments().First();

                        MethodInfo persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
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

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity: class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            string[] columns = connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

            if (modifiedEntities.Any())
            {
                connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private string GetTableName(Type tableType)
        {
            throw new NotImplementedException();
        }

        private bool IsObjectValid(object e)
        {
            var validationContext = new ValidationContext(e);
            var validationErrors = new List<ValidationResult>();

            var validationResult = Validator.TryValidateObject(e, validationContext, validationErrors, true);

            return validationResult;
        }

        private void MapAllRelations()
        {
            foreach (var dbSetProperty in dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;

                MethodInfo mapRelationGeneric = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(dbSetType);

                object dbSet = dbSetProperty.Value.GetValue(this);

                mapRelationGeneric.Invoke(this, new[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);

            MapNavigationProperties(dbSet);

            PropertyInfo[] collections = entityType.GetProperties()
                .Where(pi => 
                               pi.PropertyType.IsGenericType &&
                               pi.PropertyType
                               .GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet) 
            where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        private void InitializeDbSets()
        {
            foreach (var dbSet in dbSetProperties)
            {
                Type dbSetType = dbSet.Key;
                PropertyInfo dbSetProperty = dbSet.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PolulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            var entities = LoadTableEntities<TEntity>();

            var dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>() 
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            throw new NotImplementedException();
        }
    }
}