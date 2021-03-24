using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DB;

namespace Model.Global.Service
{
    public class MessageService : DBConfig, IMessageRepository<Message, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> Get()
        {
            throw new NotImplementedException();
        }
        
        public Message Get(int id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetMessageById", true);
            command.AddParameter("Id", id);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert).FirstOrDefault();
        }

        public Message Insert(Message entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Message employee)
        {
            throw new NotImplementedException();
        }

        public Message SendToEmployee(Message message, int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Message_SendToEmployee", true);
            command.AddParameter("Title", message.Title);
            command.AddParameter("Message", message.Text);
            command.AddParameter("SenderId", message.EmployeeId);
            command.AddParameter("ReceiverId", employeeId);
            message.Id = (int)connection.ExecuteScalar(command);
            return message ;
        }

        public Message SendToProject(Message message, int projectId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Message_SendToProject", true);
            command.AddParameter("Title", message.Title);
            command.AddParameter("Message", message.Text);
            command.AddParameter("SenderId", message.EmployeeId);
            command.AddParameter("ReceiverId", projectId);
            message.Id = (int)connection.ExecuteScalar(command);
            return message;
        }

        public Message SendToTask(Message message, int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Message_SendToTask", true);
            command.AddParameter("Title", message.Title);
            command.AddParameter("Message", message.Text);
            command.AddParameter("SenderId", message.EmployeeId);
            command.AddParameter("ReceiverId", taskId);
            message.Id = (int)connection.ExecuteScalar(command);
            return message;
        }

        public Message SendToTeam(Message message, int teamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Message_SendToTeam", true);
            command.AddParameter("Title", message.Title);
            command.AddParameter("Message", message.Text);
            command.AddParameter("SenderId", message.EmployeeId);
            command.AddParameter("ReceiverId", teamId);
            message.Id = (int)connection.ExecuteScalar(command);
            return message;
        }

        public IEnumerable<Message> GetEmployeeMessages(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeMessageByEmployeeId", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert);
        }

        public IEnumerable<Message> GetProjectMessages(int projectId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetProjectMessageByProjectId", true);
            command.AddParameter("ProjectId", projectId);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert);
        }

        public IEnumerable<Message> GetTaskMessages(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskMessageByTaskId", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert);
        }

        public IEnumerable<Message> GetTeamMessages(int teamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamMessageByTeamId", true);
            command.AddParameter("TeamId", teamId);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert);
        }

        public IEnumerable<Message> GetConversation(int messageId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetConversationByMessageId", true);
            command.AddParameter("MessageId", messageId);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert);
        }

        public Message Answer(Message answer, int messageId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_AnswerMessage", true);
            command.AddParameter("MessageId",messageId);
            command.AddParameter("Title", answer.Title);
            command.AddParameter("Message", answer.Text);
            command.AddParameter("EmployeeId", answer.EmployeeId);
            answer.Id = (int)connection.ExecuteScalar(command);
            return answer;
        }

        public Message GetLastMessage(int messageId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetMessageLastConversationMessage", true);
            command.AddParameter("MessageId", messageId);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert).SingleOrDefault();
        }

        public IEnumerable<Message> GetTeamMessagesByEmployee(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamMessageByEmployeeId", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Message> convert = (reader) => reader.ToMessage();
            return connection.ExecuteReader<Message>(command, convert);
        }
    }
}
