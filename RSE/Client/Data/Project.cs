using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Project : IDataObject
    {
        private int _Id;
        private string _Name;
        private string _Description;
        private DateTime _StartDate;
        private DateTime? _EndDate;
        private int _AdminId;
        private int _ProjectManager;

        
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime? EndDate { get => _EndDate; set => _EndDate = value; }
        public int AdminId { get => _AdminId; set => _AdminId = value; }
        public int ProjectManager { get => _ProjectManager; set => _ProjectManager = value; }


        public Project(int id, string name, string description, DateTime startdate, DateTime? enddate,int adminid, int projectmanager): this(name, description, startdate, enddate,adminid, projectmanager)
        {
            Id = id;
        }


        public Project(string name, string description, DateTime startdate, DateTime? enddate, int adminId, int projectmanager): this(name,description,startdate,enddate,projectmanager)
        {
            AdminId = adminId;
        }

        public Project(string name, string description, DateTime startdate, DateTime? enddate, int projectmanager)
        {
            Name = name;
            Description = description;
            StartDate = startdate;
            EndDate = enddate;
            ProjectManager = projectmanager;
        }

        public Project()
        {

        }
    }
}
