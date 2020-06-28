using System;
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
                    foreach (IEnumerable<object> dbSet in dbSets) //TODO: В документа е само IEnumerable тука. Да се види ако нещо не работи.
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

        private bool IsObjectValid(object e)
        {
            var validationContext = new ValidationContext(e);
            var validationErrors = new List<ValidationResult>();

            var validationResult = Validator.TryValidateObject(e, validationContext, validationErrors, true);

            return validationResult;
        }

        private void MapAllRelations()
        {
            throw new NotImplementedException();
        }

        private void InitializeDbSets()
        {
            throw new NotImplementedException();
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            throw new NotImplementedException();
        }
    }
}