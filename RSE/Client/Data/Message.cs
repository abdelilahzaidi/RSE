using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Message : IDataObject
    {
        private int _Id;
        private string _Title;
        private DateTime _Date;
        private string _Text;
        private int _EmployeeId;

        public int Id { get => _Id; set => _Id = value; }
        public string Title { get => _Title; set => _Title = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public string Text { get => _Text; set => _Text = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }

        public Message(int id, string title, DateTime date, string text, int employeeId) : this(title,text,employeeId)
        {
            Id = id;
            Date = date;
        }

        public Message(string title,string text,int employeeId)
        {
            Title = title;
            Text = text;
            EmployeeId = employeeId;
        }

        public Message()
        {

        }
    }
}
