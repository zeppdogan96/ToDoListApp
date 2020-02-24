using System.Collections.Generic;
using System.Web.Mvc;
using ToDoApplication.Common.Classes;
using ToDoApplication.Core.Classes.Task;

namespace ToDoApplication.Web.UI.Models.Task
{
    public class TaskViewModel : BaseModel
    {
        public TaskTemplate Template { get; set; } = new TaskTemplate();
        public FilterTaskTemplate FilterTemplate { get; set; } = new FilterTaskTemplate();
        public List<TaskTemplate> TemplateList { get; set; } = new List<TaskTemplate>();
        public List<SelectListItem> LevelList { get; set; } = new List<SelectListItem>();
    }
}