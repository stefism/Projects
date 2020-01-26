using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
			typeof(string),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(decimal),
			typeof(bool),
			typeof(DateTime)
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

			foreach (IEnumerable<object> dbset in dbSets)
			{
				object[] invalidEntities = dbset.Where(entity => !IsObjectValid(entity)).ToArray();

				if (invalidEntities.Any())
				{
					throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbset.GetType().Name}!");
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
							.GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
							.MakeGenericMethod(dbSetType);

						try
						{
							persistMethod.Invoke(this, new object[] { dbSet });
						}
						catch (TargetInvocationException tie)
						{
							throw tie.InnerException;
						}
						catch(InvalidOperationException)
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
			string tableName = GetTableName(typeof(TEntity));

			string[] columns = connection.FetchColumnNames(tableName).ToArray();

			if (dbSet.ChangeTracker.Added.Any())
			{
				connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
			}

			TEntity[] modifiedEntities = dbSet.ChangeTracker
				.GetModifiedEntities(dbSet).ToArray();

			if (modifiedEntities.Any())
			{
				connection.UpdateEntities(modifiedEntities, tableName, columns);
			}

			if (dbSet.ChangeTracker.Removed.Any())
			{
				connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
			}
		}

		private void MapAllRelations()
		{
			foreach (var dbsetproperty in dbSetProperties)
			{
				Type dbSetType = dbsetproperty.Key;

				MethodInfo mapRelationGeneric = typeof(DbContext)
					.GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
					.MakeGenericMethod(dbSetType);

				object dbSet = dbsetproperty.Value.GetValue(this);

				mapRelationGeneric.Invoke(this, new[] { dbSet });
			}
		}

		private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
			where TEntity : class, new()
		{
			Type entityType = typeof(TEntity);

			MapNavigationProperties(dbSet);

			PropertyInfo[] collections = entityType.GetProperties()
				.Where(pi => pi.PropertyType.IsGenericType &&
				pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
				.ToArray();

			foreach (var collection in collections)
			{
				Type collectionType = collection.PropertyType.GenericTypeArguments.First();

				MethodInfo mapCollectionMethod = typeof(DbContext)
					.GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
					.MakeGenericMethod(entityType, collectionType);

				mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
			}
		}

		private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty) where TDbSet : class, new() where TCollection : class, new()
		{
			Type entityType = typeof(TDbSet);
			Type collectionType = typeof(TCollection);

			PropertyInfo[] primaryKeys = collectionType.GetProperties()
				.Where(pi => pi.HasAttribute<KeyAttribute>()).ToArray();

			PropertyInfo primaryKey = primaryKeys.First();
			PropertyInfo foreignKey = entityType.GetProperties()
				.First(pi => pi.HasAttribute<KeyAttribute>());

			bool isManyToMany = primaryKeys.Length >= 2;

			if (isManyToMany)
			{
				primaryKey = collectionType.GetProperties()
					.First(pi => collectionType.GetProperty
					(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
					.PropertyType == entityType);
			}

			var navigationDbSet = (DbSet<TCollection>)dbSetProperties[collectionType]
				.GetValue(this);

			foreach (var entity in dbSet)
			{
				object primaryKeyValue = foreignKey.GetValue(entity);

				TCollection[] navigationEntities = navigationDbSet
					.Where(navigationEntity => primaryKey.GetValue(navigationEntity)
					.Equals(primaryKeyValue)).ToArray();

				ReflectionHelper.ReplaceBackingField
					(entity, collectionProperty.Name, navigationEntities);
			}
		}

		private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
			where TEntity : class, new()
		{
			Type entityType = typeof(TEntity);

			PropertyInfo[] foreignKeys = entityType.GetProperties()
				.Where(pi => pi.HasAttribute<ForeignKeyAttribute>()).ToArray();

			foreach (PropertyInfo foreignKey in foreignKeys)
			{
				string navigationPropertyName = foreignKey
					.GetCustomAttribute<ForeignKeyAttribute>().Name;

				PropertyInfo navigationProperty = entityType
					.GetProperty(navigationPropertyName);

				var navigationDbSet = dbSetProperties[navigationProperty.PropertyType]
					.GetValue(this);

				PropertyInfo navigationPrimaryKey = navigationProperty.PropertyType
					.GetProperties().First(pi => pi.HasAttribute<KeyAttribute>());

				foreach (TEntity entity in dbSet)
				{
					var foreignKeyValue = foreignKey.GetValue(entity);

					var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
						.First(currentNavigationProperty => navigationPrimaryKey
						.GetValue(currentNavigationProperty).Equals(foreignKeyValue));

					navigationProperty.SetValue(entity, navigationPropertyValue);
				}
			}
		}

		private static bool IsObjectValid(object e)
		{
			ValidationContext validationContext = new ValidationContext(e);
			List<ValidationResult> validationErrors = new List<ValidationResult>();

			bool validationResult = Validator.TryValidateObject
				(e, validationContext, validationErrors, validateAllProperties: true);

			return validationResult;
		}

		private IEnumerable<TEntity> LoadTableEntities<TEntity>()
			where TEntity : class
		{
			Type table = typeof(TEntity);

			var columns = GetEntityColumnNames(table);

			string tableName = GetTableName(table);

			TEntity[] fetchedRows = connection
				.FetchResultSet<TEntity>(tableName, columns).ToArray();

			return fetchedRows;
		}

		private string GetTableName(Type tableType)
		{
			string tableName = ((TableAttribute)Attribute
				.GetCustomAttribute(tableType, typeof(TableAttribute)))?.Name;

			if (tableName == null)
			{
				tableName = dbSetProperties[tableType].Name;
			}

			return tableName;
		}

		private void InitializeDbSets()
		{
			foreach (var dbSet in dbSetProperties)
			{
				Type dbSetType = dbSet.Key;
				PropertyInfo dbSetProperty = dbSet.Value;

				MethodInfo populateDbSetGeneric = typeof(DbContext)
					.GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
					.MakeGenericMethod(dbSetType);

				populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
			}
		}

		private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
			where TEntity : class, new()
		{
			var entities = LoadTableEntities<TEntity>();

			DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(entities);
			ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
		}

		private Dictionary<Type, PropertyInfo> DiscoverDbSets()
		{
			var dbSets = GetType().GetProperties()
				.Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
				.ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

			return dbSets;
		}

		private string[] GetEntityColumnNames(Type table)
		{
			string tableName = GetTableName(table);

			var dbColumns = connection.FetchColumnNames(tableName);

			string[] columns = table.GetProperties()
				.Where(pi => dbColumns.Contains(pi.Name)
				&& !pi.HasAttribute<NotMappedAttribute>()
				&& AllowedSqlTypes.Contains(pi.PropertyType))
				.Select(pi => pi.Name).ToArray();

			return columns;
		}
	}
}