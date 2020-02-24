using System;
using System.Data.Entity;
using System.Linq;
using ToDoApplication.Common.ValueTypes;
using ToDoApplication.Data;

namespace ToDoApplication.Repository
{
    public class SQLRepository: IRepository<Entities>
    {
        public Entities Context { get; set; }
        private DbContextTransaction transaction;

        public SQLRepository(Entities context)
        {
            Context = context;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Context.Set<T>().AsNoTracking();
        }

        public int Commit()
        {
            var result = Int.Zero;

            try
            {
                result = Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void RollBack()
        {
            transaction.Rollback();
        }
    }
}
