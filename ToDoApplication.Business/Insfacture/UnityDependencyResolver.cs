using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoApplication.Business.Task;
using ToDoApplication.Repository;
using Microsoft.Practices.Unity;
using ToDoApplication.Data;

namespace ToDoApplication.Business.Insfacture
{
    public sealed class UnityDependencyResolver
    {
        #region Fields
        private readonly IUnityContainer _container;
        #endregion

        #region Ctor

        public UnityDependencyResolver()
            : this(container: new UnityContainer())
        {
        }

        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this._container = container;

            ConfigureContainer(this._container);
        }
        #endregion

        #region Utilities
        private void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<Entities>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<SQLRepository>(new UnityPerExecutionContextLifetimeManager());

            container.RegisterType<ITaskService, TaskService>(new UnityPerExecutionContextLifetimeManager());
        }
        #endregion

        #region Methods
        public void Register<T>(T instance)
        {
            if (instance != null)
            {
                _container.RegisterInstance(instance);
            }
            else
            {
                throw new ArgumentNullException("instance");
            }
        }

        public void Inject<T>(T existing)
        {
            if (existing == null)
                throw new ArgumentNullException("existing");

            _container.BuildUp(existing);
        }

        public T Resolve<T>(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return (T)_container.Resolve(type);
        }

        public T Resolve<T>(Type type, string name)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (name == null)
                throw new ArgumentNullException("name");

            return (T)_container.Resolve(type, name);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            return _container.Resolve<T>(name);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            var namedInstances = _container.ResolveAll<T>();
            T unnamedInstance = default(T);

            try
            {
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {

            }

            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }

            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

        #endregion
    }
}
