using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class TaskState : IDataObject
    {
        private int _Id;
        private string _Name;

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }

        public TaskState(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
