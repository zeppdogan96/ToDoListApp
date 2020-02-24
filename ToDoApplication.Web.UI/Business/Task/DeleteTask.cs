using ToDoApplication.Business.Insfacture;
using ToDoApplication.Business.Task;
using ToDoApplication.Core.Enums;
using ToDoApplication.Web.UI.Models.Task;

namespace ToDoApplication.Web.UI.Business.Task
{
    public class DeleteTask
    {
        public void Execute(TaskViewModel model)
        {
            var result = IoC.Resolve<TaskService>().PassiveTask(model.Template);
            if (result?.HasError == false)
            {
                model.ValidationMessages.Add("Görev silindi.");
                model.NotificationTypes = NotificationTypeEnum.success;
            }
            model.TemplateList = IoC.Resolve<TaskService>().GetListTask(model.FilterTemplate).ToList();
        }
    }
}