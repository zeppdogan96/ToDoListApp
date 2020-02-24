namespace ToDoApplication.Business.Insfacture
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver CreateInstance();
    }
}
