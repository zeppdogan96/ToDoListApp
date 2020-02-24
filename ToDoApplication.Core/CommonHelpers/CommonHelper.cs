using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ToDoApplication.Common.Classes;

namespace ToDoApplication.Core.CommonHelpers
{
    public class CommonHelper
    {

    }

    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            InfoMessages = new List<string>();
            ValidationMessages = new List<string>();
        }

        public bool HasError { get; set; }
        [XmlIgnore]
        public Exception Exception { get; set; }
        public List<string> InfoMessages { get; set; }
        public List<string> ValidationMessages { get; set; }
        public int AffectedRow { get; set; }
        public T Result { get; set; }
        public int TotalItemCount { get; set; }

        public List<TaskTemplate> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
