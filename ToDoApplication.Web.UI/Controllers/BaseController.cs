using System.Web.Mvc;
using ToDoApplication.Business.Insfacture;
using ToDoApplication.Business.Task;

namespace ToDoApplication.Web.UI.Controllers
{
    public class BaseController : Controller
    {
        public ITaskService ITaskService
        {
            get { return IoC.Resolve<ITaskService>(); }
        }
    }
}