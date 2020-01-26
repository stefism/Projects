using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	internal class ChangeTracker<T>
		where T : class, new()
	{
		private readonly List<T> allEntities;

		private readonly List<T> added;

		private readonly List<T> removed;

		public ChangeTracker(IEnumerable<T> entities)
		{
			added = new List<T>();
			removed = new List<T>();

			allEntities = CloneEntities(entities);
		}

		public IReadOnlyCollection<T> AllEntities => allEntities.AsReadOnly();
		public IReadOnlyCollection<T> Added => added.AsReadOnly();
		public IReadOnlyCollection<T> Removed => removed.AsReadOnly();

		public void Add(T item) => added.Add(item);

		public void Remove(T item) => removed.Add(item);

		public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
		{
			List<T> modifiedEntities = new List<T>();

			PropertyInfo[] primaryKeys = typeof(T).GetProperties()
				.Where(pi => pi.HasAttribute<KeyAttribute>()).ToArray();

			foreach (T proxyEntity in AllEntities)
			{
				object[] primaryKeyValues 
					= GetPrimaryKeyValues(primaryKeys, proxyEntity)
					.ToArray();

				T entity = dbSet.Entities.Single(e => GetPrimaryKeyValues(primaryKeys, e)
				.SequenceEquals(primaryKeyValues));

				bool isModified = IsModified(proxyEntity, entity);

				if (isModified)
				{
					modifiedEntities.Add(entity);
				}
			}

			return modifiedEntities;
		}

		private static bool IsModified(T proxyEntity, T realEntity)
		{
			PropertyInfo[] monitoredProperties = typeof(T).GetProperties()
				.Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
				.ToArray();

			PropertyInfo[] modifiedProperties = monitoredProperties
				.Where(pi => !Equals(pi.GetValue(realEntity), pi.GetValue(proxyEntity)))
				.ToArray();

			return modifiedProperties.Any();
		}

		private static IEnumerable<object> GetPrimaryKeyValues
			(IEnumerable<PropertyInfo> primaryKeys, T entity)
		{
			return primaryKeys.Select(pk => pk.GetValue(entity));
		}

		private List<T> CloneEntities(IEnumerable<T> entities)
		{
			List<T> clonedEntities = new List<T>();

			PropertyInfo[] propertiesToClone = typeof(T).GetProperties()
				.Where(pi => DbContex.AllowedSqlTypes.Contains(pi.PropertyType))
				.ToArray();

			foreach (T entity in entities)
			{
				T clonedEntity = Activator.CreateInstance<T>();

				foreach (PropertyInfo property in propertiesToClone)
				{
					object value = property.GetValue(entity);
					property.SetValue(clonedEntity, value);
				}

				clonedEntities.Add(clonedEntity);
			}

			return clonedEntities;
		}
	}
}