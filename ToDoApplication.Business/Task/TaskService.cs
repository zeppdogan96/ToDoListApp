using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApplication.Common.Classes;
using ToDoApplication.Common.ValueTypes;
using ToDoApplication.Core.Classes.Task;
using ToDoApplication.Core.CommonHelpers;
using ToDoApplication.Data;
using ToDoApplication.Repository;

namespace ToDoApplication.Business.Task
{
    public class TaskService : BaseService<Entities>, ITaskService
    {
        public TaskService(SQLRepository repository) : base(repository)
        {
        }
        public ServiceResult<TaskTemplate> CreateTask(TaskTemplate taskTemplate)
        {
            var serviceResult = new ServiceResult<TaskTemplate>();

            try
            {
                if (taskTemplate != null)
                {

                    var task = new TASKS()
                    {
                        NAME = taskTemplate.TaskName,
                        DESCRIPTION = taskTemplate.Description,
                        STATU_ID = Int.One,
                        LEVEL_ID = taskTemplate.LevelId,
                        IS_ACTIVE = taskTemplate.IsActive,
                        IS_DELETED = taskTemplate.IsDeleted,
                        CREATE_DATE = DateTime.Now,
                        DATE = taskTemplate.Date,
                    };
                    Repository.Context.TASKS.Add(task);
                    Repository.Context.SaveChanges();
                    taskTemplate.TaskId = task.ID;
                    serviceResult.Result = taskTemplate;
                }
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.Exception = ex;
            }

            return serviceResult;
        }
        public ServiceResult<TaskTemplate> UpdateTask(TaskTemplate taskTemplate)
        {
            var serviceResult = new ServiceResult<TaskTemplate>();

            try
            {
                if (taskTemplate != null)
                {
                    var task = Repository.Context.TASKS.FirstOrDefault(a => a.ID == taskTemplate.TaskId);
                    if (task != null)
                    {
                        task.NAME = taskTemplate.TaskName;
                        task.DESCRIPTION = taskTemplate.Description;
                        task.STATU_ID = taskTemplate.StatuId;
                        task.LEVEL_ID = taskTemplate.LevelId;
                        task.IS_ACTIVE = taskTemplate.IsActive;
                        task.IS_DELETED = taskTemplate.IsDeleted;
                        //task.CREATE_DATE = taskTemplate.CreateDate;
                        task.DATE = taskTemplate.Date;
                    }
                    Repository.Context.SaveChanges();
                    serviceResult.Result = taskTemplate;
                }
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.Exception = ex;
            }
            return serviceResult;
        }
        public ServiceResult<TaskTemplate> PassiveTask(TaskTemplate taskTemplate)
        {
            var serviceResult = new ServiceResult<TaskTemplate>();

            try
            {
                if (taskTemplate != null)
                {
                    var task = Repository.Context.TASKS.FirstOrDefault(a => a.ID == taskTemplate.TaskId);
                    if (task != null)
                    {
                        task.IS_ACTIVE = false;
                        task.IS_DELETED = true;
                    }
                    Repository.Context.SaveChanges();
                    serviceResult.Result = taskTemplate;
                }
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.Exception = ex;
            }
            return serviceResult;
        }
        public ServiceResult<List<TaskTemplate>> GetListTask(FilterTaskTemplate filterTemplate)
        {
            var serviceResult = new ServiceResult<List<TaskTemplate>>();

            try
            {
                var taskList = (from task in Repository.Context.TASKS.Where(x => x.IS_ACTIVE == true && x.IS_DELETED == false)
                                select new TaskTemplate
                                {
                                    TaskId = task.ID,
                                    Description = task.DESCRIPTION,
                                    StatuId = (int)task.STATU_ID,
                                    LevelId = (int)task.LEVEL_ID,
                                    IsActive = (bool)task.IS_ACTIVE,
                                    IsDeleted = (bool)task.IS_DELETED,
                                    CreateDate = (DateTime)task.CREATE_DATE,
                                    Date = (DateTime)task.CREATE_DATE,
                                })
                                .WhereIf(filterTemplate.StartDate != null || filterTemplate.StartDate != default(DateTime), x => x.Date >= filterTemplate.StartDate)
                                .WhereIf(filterTemplate.EndDate != null || filterTemplate.EndDate != default(DateTime), x => x.Date <= filterTemplate.EndDate)
                                .WhereIf(filterTemplate.LevelId != null && filterTemplate.LevelId != Int.Zero, x => x.LevelId == filterTemplate.LevelId)
                                .WhereIf(filterTemplate.StatuId != null && filterTemplate.StatuId != Int.Zero, x => x.StatuId == filterTemplate.StatuId);

                serviceResult.Result = taskList.Page(filterTemplate.PageIndex, filterTemplate.PageSize).ToList();

            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.Exception = ex;
            }
            return serviceResult;
        }
        public ServiceResult<TaskTemplate> GetTask(int id)
        {
            var serviceResult = new ServiceResult<TaskTemplate>();

            try
            {
                var task = (from t in Repository.Context.TASKS
                            select new TaskTemplate
                            {
                                TaskId = t.ID,
                                Description = t.DESCRIPTION,
                                StatuId = (int)t.STATU_ID,
                                LevelId = (int)t.LEVEL_ID,
                                IsActive = (bool)t.IS_ACTIVE,
                                IsDeleted = (bool)t.IS_DELETED,
                                CreateDate = (DateTime)t.CREATE_DATE,
                                Date = (DateTime)t.CREATE_DATE,
                            })
                            .Where(x => x.TaskId == id)
                            .FirstOrDefault();
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.Exception = ex;
            }
            return serviceResult;
        }

    }
}
