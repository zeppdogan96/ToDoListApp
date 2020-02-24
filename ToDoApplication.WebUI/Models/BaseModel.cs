using System.Collections.Generic;
using ToDoApplication.Core.Enums;

namespace ToDoApplication.WebUI.Models
{
    public class BaseModel
    {
        public bool Result { get; set; }
        public List<string> ValidationMessages { get; set; }
        public NotificationTypeEnum NotificationTypes { get; set; }
        public int TotalItemCount { get; set; }

        public BaseModel()
        {
            ValidationMessages = new List<string>();
        }
    }
}