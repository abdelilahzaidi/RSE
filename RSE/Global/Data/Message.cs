using System;

namespace Model.Global.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int EmployeeId { get; set; }
    }
}
