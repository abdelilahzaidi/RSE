using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Department : IDataObject
    {
        private int _Id;
        private string _Name;
        private string _Description;
        private int _AdminId;        

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int AdminId { get => _AdminId; set => _AdminId = value; }

        public Department(int id, string name, string description, int adminId) : this (name,description,adminId)
        {
            Id = id;
        }

        public Department(int id, Department department) : this(id, department.Name,department.Description,department.AdminId)
        {

        }

        public Department(string name, string description, int adminId) : this(name, description)
        {
            AdminId = adminId;
        }

        public Department(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
