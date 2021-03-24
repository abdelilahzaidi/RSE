using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Data;
using Model.Client.Mapper;
using Model.Global;
using GD = Model.Global.Data;
using GS = Model.Global.Service;

namespace Model.Client.Service
{
    public class EmployeeService : IEmployeeRepository<Employee, int>
    {
        private IEmployeeRepository<GD.Employee, int> repositoryGlobal;

        public EmployeeService()
        {
            repositoryGlobal = new GS.EmployeeService();
        }


        public Employee Insert (Employee entity)
        {
            return repositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public Employee Check (Employee entity)
        {
            return repositoryGlobal.Check(entity.ToGlobal()).ToLoginClient();
        }

        public Employee Get(int Id)
        {
            return  repositoryGlobal.Get( Id).ToClient();
        }

        public bool Update(Employee entity)
        {
            return (repositoryGlobal.Update(entity.ToGlobal()));
        }

        public IEnumerable<Employee> Get()
        {
            return repositoryGlobal.Get().Select(emp => emp.ToClient());
        }

        public IEnumerable<Employee> GetByDepartment(int departmentId)
        {
            return repositoryGlobal.GetByDepartment(departmentId).Select(emp => emp.ToClient());
        }

        public bool Delete(int id)
        {
            return repositoryGlobal.Delete(id);
        }

        public bool AddToDepartment(int employeeId, int departmentId)
        {
            return repositoryGlobal.AddToDepartment(employeeId, departmentId);
        }

        public IEnumerable<Employee> GetByTeamId(int teamId)
        {
            return repositoryGlobal.GetByTeamId(teamId).Select(e => e.ToClient());
        }

        public IEnumerable<Employee> GetByProjectId(int projectId)
        {
            return repositoryGlobal.GetByProjectId(projectId).Select(e => e.ToClient());
        }

        public Employee GetByTaskId(int taskId)
        {
            return repositoryGlobal.GetByTaskId(taskId).ToClient();
        }

        public Employee GetMessageSenderByMessageId(int messageId)
        {
            return repositoryGlobal.GetMessageSenderByMessageId(messageId).ToClient();
        }

        public Employee GetMessageReceiverByMessageId(int messageId)
        {
            return repositoryGlobal.GetMessageReceiverByMessageId(messageId).ToClient();
        }

        public IEnumerable<Employee> GetByMessageId(int messageId)
        {
            return repositoryGlobal.GetByMessageId(messageId).Select(e => e.ToClient());
        }
    }
}
