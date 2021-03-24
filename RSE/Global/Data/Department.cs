using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AdminId { get; set; }
    }
    /*
    public class DepartmentList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
    }
    */
}
