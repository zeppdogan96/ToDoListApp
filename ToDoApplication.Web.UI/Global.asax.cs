using System.Web.Mvc;
using System.Web.Routing;
using ToDoApplication.Business.Insfacture;

namespace ToDoApplication.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IoC.CreateContainer();
        }
    }
}
