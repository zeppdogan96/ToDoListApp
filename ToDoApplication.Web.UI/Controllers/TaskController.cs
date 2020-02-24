using System.Web.Mvc;
using ToDoApplication.Business.Insfacture;
using ToDoApplication.Business.Task;
using ToDoApplication.Common.Enums.Task;
using ToDoApplication.Core.CommonHelpers;
using ToDoApplication.Core.Enums;
using ToDoApplication.Web.UI.Models.Task;

namespace ToDoApplication.Web.UI.Controllers
{
    public class TaskController : BaseController
    {
        // GET: Task
        public ActionResult Index(TaskViewModel model)
        {
            FillStatusDropDown(model);
            var result = ITaskService.GetListTask(model.FilterTemplate);

            model.TemplateList = result.Result;
            model.TotalItemCount = result.TotalItemCount;
            return View(model);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(TaskViewModel model)
        {
            Validations(model);
            if (model.ValidationMessages.Count > decimal.Zero)
            {
                model.TemplateList = ITaskService.GetListTask(model.FilterTemplate).ToList();
                model.NotificationTypes = NotificationTypeEnum.warning;
                return RedirectToAction("Insert");
            }

            var result = ITaskService.CreateTask(model.Template);
            model.TemplateList = ITaskService.GetListTask(model.FilterTemplate).ToList();
            if (result?.HasError == false)
            {
                model.ValidationMessages.Add("İşlem Başarılı.");
                model.NotificationTypes = NotificationTypeEnum.success;
                return RedirectToAction("Index");
            }

            model.ValidationMessages.Add("Hata Oluştu.");
            model.NotificationTypes = NotificationTypeEnum.error;
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var task = ITaskService.GetTask(id);
            return View(task);
        }
        [HttpPost]
        public ActionResult Update(TaskViewModel model)
        {
            var result = ITaskService.UpdateTask(model.Template);
            if (result?.HasError == false)
            {
                model.ValidationMessages.Add("Görev silindi.");
                model.NotificationTypes = NotificationTypeEnum.success;
            }
            model.TemplateList = ITaskService.GetListTask(model.FilterTemplate).ToList();
            return RedirectToAction("Index");
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(TaskViewModel model)
        {
            var result = ITaskService.PassiveTask(model.Template);
            if (result?.HasError == false)
            {
                model.ValidationMessages.Add("Görev silindi.");
                model.NotificationTypes = NotificationTypeEnum.success;
            }
            model.TemplateList = ITaskService.GetListTask(model.FilterTemplate).ToList();
            return RedirectToAction("Index");
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

        private static void FillStatusDropDown(TaskViewModel model)
        {
            model.LevelList.Add(new SelectListItem { Text = "Seviye Seçiniz", Value = string.Empty });
            model.LevelList.Add(new SelectListItem { Text = "Genel", Value = TaskImportanceLevelEnum.Common.ToString() });
            model.LevelList.Add(new SelectListItem { Text = "Acil", Value = TaskImportanceLevelEnum.Urgent.ToString() });
            model.LevelList.Add(new SelectListItem { Text = "Kritik", Value = TaskImportanceLevelEnum.Critial.ToString() });
        }
    }
}