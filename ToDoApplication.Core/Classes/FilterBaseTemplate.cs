using ToDoApplication.Common.ValueTypes;

namespace ToDoApplication.Core.Classes
{
    public class FilterBaseTemplate
    {
        public int PageSize { get; set; } = Int.Twenty;
        public int PageIndex { get; set; } = Int.One;
    }
}
