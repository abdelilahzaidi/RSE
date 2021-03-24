using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Global.Data;

namespace Model.Global.Mapper
{
    internal static class Mapper
    {
        #region Employee
        internal static Employee ToEmployee(this IDataRecord dr)
        {
            return new Employee()
            {
                Id = (int)dr["id"],
                LastName = (string)dr["LastName"],
                FirstName = (string)dr["FirstName"],
                Email = (string)dr["Email"],
                Password = "********",//(string)dr["Password"],
                RegNat = (string)dr["RegNat"],
                HireDate = (DateTime)dr["HireDate"],
                Active = (bool)dr["Active"],
                Avatar = (dr["Avatar"] != DBNull.Value) ? (string)dr["Avatar"] : null,
                City = (string)dr["City"],
                Street = (string)dr["Street"],
                Number = (string)dr["Number"],
                NumberBox = (dr["NumberBox"] != DBNull.Value) ? (string)dr["NumberBox"] : null,
                ZipCode = (string)dr["ZipCode"],
                Country = (string)dr["Country"],
                GSM = (int)dr["GSM"],
                BirthDate = (DateTime)dr["BirthDate"]
            };
        }

        internal static Employee ToEmployeeLogin(this IDataRecord dr)
        {
            return new Employee()
            {
                Id = (int)dr["id"],
                Email = (string)dr["Email"]
            };
        }
        #endregion

        #region EmployeeState
        internal static Employee_EmployeeState ToEmployee_EmployeeState(this IDataRecord dr)
        {
            if (dr==null)
                return null;
            return new Employee_EmployeeState
            {
                Id = (int)dr["Id"],
                EmployeeId = (int)dr["EmployeeId"],
                EmployeeStateId = (int)dr["EmployeeStateId"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate =(DateTime)dr["EndDate"]
            };
        }

        internal static EmployeeState ToEmployeeState(this IDataRecord dr)
        {
            if (dr==null)
                return null;
            return new EmployeeState
            {
                Id = (int)dr["Id"],
                Name = (string)dr["Name"]
            };
        }
        #endregion

        #region Admin
        internal static Admin ToAdmin(this IDataRecord dr)
        {
            return new Admin()
            {
                AdminId = (int)dr["AdminId"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (dr["EndDate"] != DBNull.Value) ? (DateTime?)dr["EndDate"] : null,
                EmployeeId = (int)dr["EmployeeId"],
                LastName = (string)dr["LastName"],
                FirstName = (string)dr["FirstName"],
                Email = (string)dr["Email"],
                Password = "********",//(string)dr["Password"],
                RegNat = (string)dr["RegNat"],
                HireDate = (DateTime)dr["HireDate"],
                Active = (bool)dr["Active"],
                Avatar = (dr["Avatar"] != DBNull.Value) ? (string)dr["Avatar"] : null,
                City = (string)dr["City"],
                Street = (string)dr["Street"],
                Number = (string)dr["Number"],
                NumberBox = (dr["NumberBox"] != DBNull.Value) ? (string)dr["NumberBox"] : null,
                ZipCode = (string)dr["ZipCode"],
                Country = (string)dr["Country"],
                GSM = (int)dr["GSM"],
                BirthDate = (DateTime)dr["BirthDate"]
            };
        }

        internal static Admin ToAdminLogin(this IDataRecord dr)
        {
            return new Admin
            {
                EmployeeId = (int)dr["EmployeeId"],
                Email = (string)dr["Email"],
                AdminId = (int)dr["AdminId"]
            };
        }
        #endregion

        #region Department
        internal static Department ToDepartment(this IDataRecord dr)
        {
            return new Department()
            {
                Id = (int)dr["id"],
                Name = (string)dr["Name"],
                Description = (dr["Description"] != DBNull.Value) ? (string)dr["Description"] : null,
                AdminId = (int)dr["AdminId"]
            };
        }
        #endregion

        #region Project
        internal static Project ToProject(this IDataRecord dr)
        {
            return new Project()
            {
                Id = (int)dr["id"],
                Name = (string)dr["Name"],
                Description = (string)dr["Description"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (dr["EndDate"] != DBNull.Value) ? (DateTime?)dr["EndDate"] : null,
                AdminId = (int)dr["AdminId"],
                ProjectManager = (int)dr["EmployeeId"]
            };
        }
        #endregion

        #region Event
        internal static Event ToEvent(this IDataRecord dr)
        {
            return new Event()
            {
                Id = (int)dr["id"],
                Name = (string)dr["Name"],
                Description = (dr["Description"] != DBNull.Value) ? (string)dr["Description"] : null,
                City = (string)dr["City"],
                Street = (string)dr["Street"],
                Number = (string)dr["Number"],
                NumberBox = (dr["NumberBox"] != DBNull.Value) ? (string)dr["NumberBox"] : null,
                ZipCode = (string)dr["ZipCode"],
                Country = (string)dr["Country"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (dr["EndDate"] != DBNull.Value) ? (DateTime?)dr["EndDate"] : null,
                FullDay = (bool)dr["FullDay"],
                EmployeeId = (int)dr["EmployeeId"]


            };
        }
        #endregion

        #region Task
        internal static Task ToTask(this IDataRecord dr)
        {
            return new Task
            {
                Id = (int)dr["Id"],
                Name = (string)dr["Name"],
                Description = (dr["Description"] != DBNull.Value) ? (string)dr["Description"] : null,
                StartDate = (DateTime)dr["StartDate"],
                DeadLine = (DateTime)dr["DeadLine"],
                ProjectId = (int)dr["ProjectId"],
                TaskTeam = (bool)dr["TaskTeam"],
                MainTaskId = (dr["MainTaskId"] != DBNull.Value) ? (int?)dr["MainTaskId"] : null
            };
        }

        #region TaskState
        internal static TaskState ToTaskState(this IDataRecord dr)
        {
            if (dr["Id"] == DBNull.Value)
                return null;
            return new TaskState {
                Id = (int)dr["Id"],
                Name = (string)dr["Name"]
            };
        }
        #endregion
        #endregion

        #region MessageMapper
        internal static Message ToMessage(this IDataRecord dr)
        {
            return new Message()
            {
                Id = (int)dr["Id"],
                Title = (string)dr["Title"],
                Date = (DateTime)dr["Date"],
                Text = (string)dr["Message"],
                EmployeeId = (int)dr["EmployeeId"]
            };
        }
        #endregion

        #region Team
        internal static Team ToTeam(this IDataRecord dr)
        {
            return new Team()
            {
                Id = (int)dr["id"],
                Name = (string)dr["Name"],
                CreateDate = (DateTime)dr["CreateDate"],
                ProjectId = (int)dr["ProjectId"],
                TeamManagerId = (int)dr["EmployeeId"]


            };
        }
        internal static Document ToDocument(this IDataRecord dr)
        {
            return new Document()
            {
                Id = (int)dr["Id"],
                Name = (string)dr["Name"],
                Description = (dr["Description"]!=DBNull.Value)?(string)dr["Description"]:null,
                CreateDate = (DateTime)dr["CreateDate"],           
                Extention = (string)dr["Extention"],
                EmployeeId = (int)dr["EmployeeId"],                
                FileBinId = (int)dr["FileBinId"],
                OldFileId = (dr["OldFileId"]!=DBNull.Value)?(int?)dr["OldFileId"]:null,
                Size = (long)dr["Size"]
            };
        }
        internal static Bin ToBin(this IDataRecord dr)
        {
            return new Bin()
            {
                Id = (int)dr["Id"],
                Binaries = (byte[])dr["Bin"],
                UploadDate = (DateTime)dr["UploadDate"],
                UploadName = (string)dr["UploadName"],
            };
        }
        #endregion

        #region Invite
        internal static Invite ToInvite(this IDataRecord dr)
        {
            if (dr == null)
                return null;
            return new Invite()
            {
                EmployeeId = (int)dr["EmployeeId"],
                EventId = (int)dr["EventId"],
                Present = (dr["Present"] == DBNull.Value) ? null : (bool?)dr["Present"]
            };
        }
        #endregion

        #region Planning
        internal static PlanningItem ToPlanning(this IDataRecord dr)
        {
            if (dr == null)
            {
                return null;
            }
            return new PlanningItem()
            {
                Id = (int)dr["Id"],
                Name = (string)dr["Name"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (DateTime)dr["EndDate"],
                EmployeeId = (int)dr["EmployeeId"],
                Type = (string)dr["Type"]
            };


        }

        #endregion

    }
}
