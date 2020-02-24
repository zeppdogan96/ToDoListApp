using System.ComponentModel;
using ToDoApplication.Common.ValueTypes;

namespace ToDoApplication.Common.Enums.Task
{
    public enum TaskImportanceLevelEnum
    {
        [Description("Genel")]
        Common = Int.One,
        [Description("Acil")]
        Urgent,
        [Description("Kritik")]
        Critial
    }
}
