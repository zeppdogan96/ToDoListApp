using System.Collections.Generic;
using ToDoApplication.Common.Classes;
using ToDoApplication.Core.Classes.Task;
using ToDoApplication.Core.CommonHelpers;

namespace ToDoApplication.Business.Task
{
    public interface ITaskService
    {
        ServiceResult<TaskTemplate> CreateTask(TaskTemplate taskTemplate);
        ServiceResult<TaskTemplate> UpdateTask(TaskTemplate taskTemplate);
        ServiceResult<TaskTemplate> PassiveTask(TaskTemplate taskTemplate);
        ServiceResult<List<TaskTemplate>> GetListTask(FilterTaskTemplate filterTemplate);
        ServiceResult<TaskTemplate> GetTask(int id);
    }
}
