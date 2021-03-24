using Model.Global;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CD = Model.Client.Data;
using System.Threading.Tasks;
using Model.Client.Mapper;

namespace Model.Client.Service
{
    public class TaskService : ITaskRepository<CD.Task, int>
    {
        public ITaskRepository<GD.Task, int> repositoryGlobal { get; set; }

        public TaskService()
        {
            repositoryGlobal = new GS.TaskService();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CD.Task> Get()
        {
            return repositoryGlobal.Get().Select(t=>t.ToClient());
        }

        public CD.Task Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public CD.Task Insert(CD.Task entity)
        {
            return repositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public bool Update(CD.Task task)
        {
            return repositoryGlobal.Update(task.ToGlobal());
        }

        public IEnumerable<CD.Task> GetByProjectId(int projectId)
        {
            return repositoryGlobal.GetByProjectId(projectId).Select(t => t.ToClient());
        }

        public IEnumerable<CD.Task> GetMainHierarchy(int taskId)
        {
            return repositoryGlobal.GetMainHierarchy(taskId).Select(t => t.ToClient());
        }

        public IEnumerable<CD.Task> GetSubHierarchy(int taskId)
        {
            return repositoryGlobal.GetSubHierarchy(taskId).Select(t => t.ToClient());
        }

        public bool InsertMainTask(int taskId, int mainTaskId)
        {
            return repositoryGlobal.InsertMainTask(taskId,mainTaskId);
        }

        public bool UpdateMainTask(int taskId, int mainTaskId)
        {
            return repositoryGlobal.UpdateMainTask(taskId, mainTaskId);
        }

        public bool DeleteMainTask(int taskId)
        {
            return repositoryGlobal.DeleteMainTask(taskId);
        }

        public bool InsertTaskState(int taskId, int taskStateId)
        {
            return repositoryGlobal.InsertTaskState(taskId,taskStateId);
        }

        public CD.Task GetMainTask(int taskId)
        {
            return repositoryGlobal.GetMainTask(taskId).ToClient();
        }

        public bool AssignTeam(int taskId, int teamId)
        {
            return repositoryGlobal.AssignTeam(taskId,teamId);
        }

        public bool AssignEmployee(int taskId, int employeeId)
        {
            return repositoryGlobal.AssignEmployee(taskId,employeeId);
        }

        public IEnumerable<CD.Task> GetByEmployeeId(int employeeId)
        {
            return repositoryGlobal.GetByEmployeeId(employeeId).Select(t => t.ToClient());
        }

        /*OLD PROCEDURE
         * 
         * public bool SetTask_TaskTeam(int taskId)
        {
            return repositoryGlobal.SetTask_TaskTeam(taskId);
        }

        public bool SetTask_TaskEmployee(int taskId)
        {
            return repositoryGlobal.SetTask_TaskEmployee(taskId);
        }*/
    }
}
