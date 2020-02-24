using System;

namespace ToDoApplication.Business.Insfacture
{
    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly Type _resolverType;
        public DependencyResolverFactory() : this("ToDoApplication.Business.Insfacture.UnityDependencyResolver, ToDoApplication.Business")
        {
        }

        public DependencyResolverFactory(string resolverTypeName)
        {
            if (String.IsNullOrEmpty(resolverTypeName))
            {
                throw new ArgumentNullException("resolverTypeName");
            }
            
            _resolverType = Type.GetType(resolverTypeName, true, true);
        }
        public IDependencyResolver CreateInstance()
        {
            return Activator.CreateInstance(_resolverType) as IDependencyResolver;
        }
    }
}
