using System;
using System.Collections.Generic;
using ToDoApplication.Core.CommonHelpers;
using ToDoApplication.Core.Enums;

namespace ToDoApplication.Web.UI.Models
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

        public R Bind<R>(ServiceResult<R> value)
        {
            var returnValue = new object();

            if (value.Result != null)
            {
                returnValue = value.Result;
            }
            else
            {
                returnValue = new List<R>();
            }

            Type type = typeof(R);
            if (type.Namespace == "System.Collections.Generic")
            {
                TotalItemCount = value.TotalItemCount;
            }

            return (R)returnValue;
        }
    }
}