using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MiniORM
{
	public class DbSet<TEntity> : ICollection<TEntity>
		where TEntity : class, new()
	{
		public DbSet(IEnumerable<TEntity> entities)
		{
			Entities = entities.ToList();
			ChangeTracker = new ChangeTracker<TEntity>(entities);
		}
		internal ChangeTracker<TEntity> ChangeTracker { get; set; }

		internal IList<TEntity> Entities { get; set; }

		public int Count => Entities.Count;
		
		public bool IsReadOnly => Entities.IsReadOnly;

		public void Add(TEntity item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item), "Item cannot be null!");
			}

			Entities.Add(item);

			ChangeTracker.Add(item);
		}

		public void Clear()
		{
			while (Entities.Any())
			{
				TEntity entity = Entities.First();
				Remove(entity);
			}
		}

		public bool Contains(TEntity item) => Entities.Contains(item);

		public void CopyTo(TEntity[] array, int startIndex) 
		{
			Entities.CopyTo(array, startIndex);
		}

		public bool Remove(TEntity item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item), "Item cannot be null!");
			}

			bool removedSuccesfully = Entities.Remove(item);

			if (removedSuccesfully)
			{
				ChangeTracker.Remove(item);
			}

			return removedSuccesfully;
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			foreach (TEntity entity in entities.ToArray())
			{
				Remove(entity);
			}
		}

		public IEnumerator<TEntity> GetEnumerator()
		{
			return Entities.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}