using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Task : IDataObject
    {
        private int _Id;
        private string _Name;
        private string _Description;
        private DateTime _StartDate;
        private DateTime _DeadLine;
        private int _ProjectId;
        private bool _TaskTeam;
        private int? _MainTaskId;

        public int Id {get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime DeadLine { get => _DeadLine; set => _DeadLine = value; }
        public int ProjectId { get => _ProjectId; set => _ProjectId = value; }
        public bool TaskTeam { get => _TaskTeam; set => _TaskTeam = value; }
        public int? MainTaskId { get => _MainTaskId; set => _MainTaskId = value; }

        public Task(string name, string description, DateTime startdate, DateTime deadline, int projectId, bool taskTeam)
        {
            Name = name;
            Description = description;
            StartDate = startdate;
            DeadLine = deadline;
            ProjectId = projectId;
            TaskTeam = taskTeam;
        }

        public Task(string name, string description, DateTime startdate, DateTime deadline, int projectId, bool taskTeam, int? mainTaskId):this(name,description,startdate,deadline,projectId,taskTeam)
        {
            MainTaskId = mainTaskId;
        }

        public Task(int id,string name,string description,DateTime startdate,DateTime deadline, int projectId, bool taskTeam, int? mainTaskId) : this(name,description,startdate,deadline,projectId,taskTeam,mainTaskId)
        {
            Id = id;
        }
        
    }
}
