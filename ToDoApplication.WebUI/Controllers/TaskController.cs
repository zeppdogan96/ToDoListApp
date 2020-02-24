using System.Web.Mvc;
using ToDoApplication.WebUI.Models.Task;

namespace ToDoApplication.WebUI.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertTask()
        {
            var model = new TaskViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult FaultReport(TaskViewModel model)
        {
            ModelState.Clear();

            return PartialView("FaultReportPartial", model);
        }
    }
}