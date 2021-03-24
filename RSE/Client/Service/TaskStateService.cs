using Model.Client.Data;
using Model.Global;
using GD = Model.Global.Data;
using GS = Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Mapper;

namespace Model.Client.Service
{
    public class TaskStateService : ITaskStateRepository<TaskState, int>
    {
        private ITaskStateRepository<GD.TaskState, int> repositoryGlobal { get; set; }
        
        public TaskStateService()
        {
            repositoryGlobal = new GS.TaskStateService();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskState> Get()
        {
            return repositoryGlobal.Get().Select(ts=>ts.ToClient());
        }

        public TaskState Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public TaskState GetByTaskId(int taskId)
        {
            return repositoryGlobal.GetByTaskId(taskId).ToClient();
        }

        public TaskState Insert(TaskState entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TaskState employee)
        {
            throw new NotImplementedException();
        }
    }
}
