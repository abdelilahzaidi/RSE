using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Client.Data
{
    public class Team
    {
        #region fields
        private int _Id;
        private string _Name;
        private DateTime _CreateDate;
        private int _ProjectId;
        private int _TeamManagerId;
      
        #endregion

        #region Props
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public DateTime CreateDate { get => _CreateDate; set => _CreateDate = value; }
        public int ProjectId { get => _ProjectId; set => _ProjectId = value; }
        public int TeamManagerId { get => _TeamManagerId; set => _TeamManagerId = value; }
        #endregion
        #region ctor
        public Team(int id, string name, DateTime createdate, int projectid,int teammanagerid) : this (name, createdate, projectid,teammanagerid)
        {
            Id = id;
        }
        public Team(string name, DateTime createdate, int projectid, int teamManagerId):this(name,projectid,teamManagerId)
        {
            CreateDate = createdate;
        }
        public Team()
        {

        }
        public Team(string name,int projectid,int teammanagerid)
        {
            Name = name;
            ProjectId = projectid;
            TeamManagerId = teammanagerid;
            
        }
        public Team(int id, string name)
        {
            Name = name;
            Id = id;
           
        }
        #endregion

    }
}
