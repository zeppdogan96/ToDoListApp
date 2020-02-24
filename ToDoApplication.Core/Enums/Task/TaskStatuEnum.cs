using System.ComponentModel;
using ToDoApplication.Common.ValueTypes;

namespace ToDoApplication.Common.Enums.Task
{
    public enum TaskStatuEnum
    {
        [Description("Tamamlanmadı")]
        Incomplete=Int.One,
        [Description("Tamamlandı")]
        Completed,
    }
}
