using ToDoApplication.Business.Insfacture;
using ToDoApplication.Business.Task;
using ToDoApplication.WebUI.Models.Task;

namespace ToDoApplication.WebUI.Business.Task
{
    public class GetListTask
    {
        public void Execute(TaskViewModel model)
        {
            var result = IoC.Resolve<TaskService>().GetListTask(model.FilterTemplate);

            model.TemplateList = result.Result;
            model.TotalItemCount = result.TotalItemCount;
        }
    }
}