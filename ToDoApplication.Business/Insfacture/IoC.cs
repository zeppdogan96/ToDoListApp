using Autofac;
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
        //#region Fields
        //private static IDependencyResolver _resolver;
        //#endregion

        //#region Methods
        //public static void InitializeWith(IDependencyResolverFactory factory)
        //{
        //    if (factory == null)
        //        throw new ArgumentNullException("factory");

        //    _resolver = factory.CreateInstance();
        //}

        //public static void Register<T>(T instance)
        //{
        //    if (instance == null)
        //        throw new ArgumentNullException("instance");

        //    _resolver.Register(instance);
        //}

        //public static void Inject<T>(T existing)
        //{
        //    if (existing == null)
        //        throw new ArgumentNullException("existing");

        //    _resolver.Inject(existing);
        //}

        //public static T Resolve<T>(Type type)
        //{
        //    if (type == null)
        //        throw new ArgumentNullException("type");

        //    return _resolver.Resolve<T>(type);
        //}

        //public static T Resolve<T>(Type type, string name)
        //{
        //    if (type == null)
        //        throw new ArgumentNullException("type");
        //    if (name == null)
        //        throw new ArgumentNullException("name");

        //    return _resolver.Resolve<T>(type, name);
        //}

        //public static T Resolve<T>()
        //{
        //    return _resolver.Resolve<T>();
        //}

        //public static T Resolve<T>(string name)
        //{
        //    if (String.IsNullOrEmpty(name))
        //        throw new ArgumentNullException("name");

        //    return _resolver.Resolve<T>(name);
        //}

        //public static IEnumerable<T> ResolveAll<T>()
        //{
        //    return _resolver.ResolveAll<T>();
        //}
        //#endregion

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
                //Builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
                //Builder.RegisterType<PageService>().As<IPageService>().InstancePerDependency();
                //Builder.RegisterType<ProductionService>().As<IProductionService>().InstancePerDependency();
                //Builder.RegisterType<BlockService>().As<IBlockService>().InstancePerDependency();
                //Builder.RegisterType<PackageService>().As<IPackageService>().InstancePerDependency();
                //Builder.RegisterType<ModelService>().As<IModelService>().InstancePerDependency();
                //Builder.RegisterType<PrintService>().As<IPrintService>().InstancePerDependency();
                //Builder.RegisterType<ForecastService>().As<IForecastService>().InstancePerDependency();
                //Builder.RegisterType<PurchaseService>().As<IPurchaseService>().InstancePerDependency();
                //Builder.RegisterType<RTFService>().As<IRTFService>().InstancePerDependency();
                //Builder.RegisterType<TransferService>().As<ITransferService>().InstancePerDependency();
                //Builder.RegisterType<OrderService>().As<IOrderService>().InstancePerDependency();
                //Builder.RegisterType<ZoneService>().As<IZoneService>().InstancePerDependency();
                //Builder.RegisterType<NotificationService>().As<INotificationService>().InstancePerDependency();
                //Builder.RegisterType<SettingService>().As<ISettingService>().InstancePerDependency();
                //Builder.RegisterType<JobService>().As<IJobService>().InstancePerDependency();
                //Builder.RegisterType<JobLiveViewService>().As<IJobLiveViewService>().InstancePerDependency();
                //Builder.RegisterType<ReportService>().As<IReportService>().InstancePerDependency();
                //Builder.RegisterType<DefinitionService>().As<IDefinitionService>().InstancePerDependency();
                //Builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
                //Builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerDependency();
            }
        }

        public static Autofac.IContainer CreateContainer()
        {
            Container = Builder.Build();
            return Container;
        }

        public static T Resolve<T>()
        {
            //Container = Builder.Build();
            return Container.Resolve<T>();
        }
    }
}
