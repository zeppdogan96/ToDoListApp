using System.Linq;

namespace ToDoApplication.Repository
{
    public interface IRepository<R>
    {
            R Context { get; set; }
            IQueryable<T> Query<T>() where T : class;
            int Commit();
            void RollBack();
        
    }
}
