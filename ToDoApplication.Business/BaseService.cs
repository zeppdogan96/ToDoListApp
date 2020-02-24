using ToDoApplication.Repository;

namespace ToDoApplication.Business
{
    public class BaseService<T>
    {
        //private SQLRepository repository;

        //public IRepository<T> Repository { get; set; }

        //public BaseService(IRepository<T> repository)
        //{
        //    Repository = repository;
        //}

        //public BaseService(SQLRepository repository)
        //{
        //    this.repository = repository;
        //}

        public IRepository<T> Repository { get; set; }

        public BaseService(IRepository<T> repository)
        {
            Repository = repository;
        }
    }
}
