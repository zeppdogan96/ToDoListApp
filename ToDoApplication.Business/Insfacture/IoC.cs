﻿using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ToDoApplication.Business.Task;
using ToDoApplication.Data;
using ToDoApplication.Repository;

namespace ToDoApplication.Business.Insfacture
{
    public static class IoC
    {
        public static ContainerBuilder Builder;
        private static Autofac.IContainer Container;

        static IoC()
        {
            if (Builder == null)
            {
                Builder = new ContainerBuilder();
                Builder.RegisterType<Entities>();
                Builder.RegisterType<SQLRepository>().InstancePerDependency();
                Builder.RegisterType<TaskService>().As<ITaskService>().InstancePerDependency();
            }
        }

        public static Autofac.IContainer CreateContainer()
        {
            Container = Builder.Build();
            return Container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
        /* #region Fields
       private static IDependencyResolver _resolver;
       #endregion

       #region Methods
       public static void InitializeWith(IDependencyResolverFactory factory)
       {
           if (factory == null)
               throw new ArgumentNullException("factory");

           _resolver = factory.CreateInstance();
       }

       public static void Register<T>(T instance)
       {
           if (instance == null)
               throw new ArgumentNullException("instance");

           _resolver.Register(instance);
       }

       public static void Inject<T>(T existing)
       {
           if (existing == null)
               throw new ArgumentNullException("existing");

           _resolver.Inject(existing);
       }

       public static T Resolve<T>(Type type)
       {
           if (type == null)
               throw new ArgumentNullException("type");

           return _resolver.Resolve<T>(type);
       }

       public static T Resolve<T>(Type type, string name)
       {
           if (type == null)
               throw new ArgumentNullException("type");
           if (name == null)
               throw new ArgumentNullException("name");

           return _resolver.Resolve<T>(type, name);
       }

       public static T Resolve<T>()
       {
           return _resolver.Resolve<T>();
       }

       public static T Resolve<T>(string name)
       {
           if (String.IsNullOrEmpty(name))
               throw new ArgumentNullException("name");

           return _resolver.Resolve<T>(name);
       }

       public static IEnumerable<T> ResolveAll<T>()
       {
           return _resolver.ResolveAll<T>();
       }
       #endregion*/
    }
}
