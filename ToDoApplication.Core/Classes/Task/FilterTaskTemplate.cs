using System;

namespace ToDoApplication.Core.Classes.Task
{
    public class FilterTaskTemplate : FilterBaseTemplate
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StatuId { get; set; }
        public int? LevelId { get; set; }
    }
}
