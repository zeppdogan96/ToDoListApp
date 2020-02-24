using ToDoApplication.Business.Insfacture;
using ToDoApplication.Business.Task;
using ToDoApplication.Core.CommonHelpers;
using ToDoApplication.Core.Enums;
using ToDoApplication.Web.UI.Models.Task;

namespace ToDoApplication.Web.UI.Business.Task
{
    public class InsertTask
    {
        public void Execute(TaskViewModel model)
        {
            Validations(model);
            if (model.ValidationMessages.Count > decimal.Zero)
            {
                model.TemplateList = IoC.Resolve<TaskService>().GetListTask(model.FilterTemplate).ToList();
                model.NotificationTypes = NotificationTypeEnum.warning;
                return;
            }

            var result = IoC.Resolve<TaskService>().CreateTask(model.Template);
            model.TemplateList = IoC.Resolve<TaskService>().GetListTask(model.FilterTemplate).ToList();
            if (result?.HasError == false)
            {
                model.ValidationMessages.Add("İşlem Başarılı.");
                model.NotificationTypes = NotificationTypeEnum.success;
                return;
            }

            model.ValidationMessages.Add("Hata Oluştu.");
            model.NotificationTypes = NotificationTypeEnum.error;
        }

        private void Validations(TaskViewModel model)
        {
            if (model.Template.TaskName.IsNull())
            {
                model.ValidationMessages.Add("Görev İsmi Boş Bırakılamaz!");
                return;
            }

            if (model.Template.Description.IsNull())
            {
                model.ValidationMessages.Add("Görev Açıklaması Boş Bırakılamaz!");
                return;
            }

            if (model.Template.Date.IsNull() || model.Template.Date == default)
            {
                model.ValidationMessages.Add("Görev Tarihi Boş Bırakılamaz!!");
                return;
            }
        }
    }
}