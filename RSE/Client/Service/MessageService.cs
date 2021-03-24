using CD = Model.Client.Data;
using GD = Model.Global.Data;
using GS = Model.Global.Service;
using Model.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Mapper;

namespace Model.Client.Service
{
    public class MessageService : IMessageRepository<CD.Message, int>
    {
        private IMessageRepository<GD.Message, int> repositoryGlobal{get;set;}

        public MessageService()
        {
            repositoryGlobal = new GS.MessageService();
        }

        public IEnumerable<CD.Message> Get()
        {
            throw new NotImplementedException();
        }

        public CD.Message Insert(CD.Message entity)
        {
            throw new NotImplementedException();
        }

        public CD.Message Get(int id)
        {
            return repositoryGlobal.Get(id).ToClient();
        }

        public bool Update(CD.Message employee)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CD.Message SendToEmployee(CD.Message message, int employeeId)
        {
            return repositoryGlobal.SendToEmployee(message.ToGlobal(),employeeId).ToClient();
        }

        public CD.Message SendToTeam(CD.Message message, int teamId)
        {
            return repositoryGlobal.SendToTeam(message.ToGlobal(), teamId).ToClient();
        }

        public CD.Message SendToProject(CD.Message message, int projectId)
        {
            return repositoryGlobal.SendToProject(message.ToGlobal(), projectId).ToClient();
        }

        public CD.Message SendToTask(CD.Message message, int taskId)
        {
            return repositoryGlobal.SendToTask(message.ToGlobal(), taskId).ToClient();
        }

        public IEnumerable<CD.Message> GetEmployeeMessages(int employeeId)
        {
            return repositoryGlobal.GetEmployeeMessages(employeeId).Select(m => m.ToClient());
        }

        public IEnumerable<CD.Message> GetProjectMessages(int projectId)
        {
            return repositoryGlobal.GetProjectMessages(projectId).Select(m => m.ToClient());
        }

        public IEnumerable<CD.Message> GetTaskMessages(int taskId)
        {
            return repositoryGlobal.GetTaskMessages(taskId).Select(m => m.ToClient());
        }

        public IEnumerable<CD.Message> GetTeamMessages(int teamId)
        {
            return repositoryGlobal.GetTeamMessages(teamId).Select(m => m.ToClient());
        }

        public IEnumerable<CD.Message> GetConversation(int messageId)
        {
            return repositoryGlobal.GetConversation(messageId).Select(m => m.ToClient());
        }

        public CD.Message Answer (CD.Message answer,int messageId)
        {
            return repositoryGlobal.Answer(answer.ToGlobal(), messageId).ToClient();
        }

        public CD.Message GetLastMessage(int messageId)
        {
            return repositoryGlobal.GetLastMessage(messageId).ToClient();
        }

        public IEnumerable<CD.Message> GetTeamMessagesByEmployee(int employeeId)
        {
            return repositoryGlobal.GetTeamMessagesByEmployee(employeeId).Select(m=>m.ToClient());
        }
    }
}
