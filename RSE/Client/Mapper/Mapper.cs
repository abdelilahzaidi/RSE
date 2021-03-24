using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = Model.Client.Data;
using G = Model.Global.Data;

namespace Model.Client.Mapper
{
    internal static class Mapper
    {
        #region AdminMapper
        internal static G.Admin ToGlobal(this C.Admin admin)
        {
            return new G.Admin() {
                AdminId = admin.AdminId,
                StartDate = admin.StartDate,
                EndDate=admin.EndDate,
                EmployeeId = admin.Id,
                LastName = admin.LastName,
                FirstName = admin.FirstName,
                Email = admin.Email,
                Password = admin.Password,
                RegNat = admin.RegNat,
                HireDate = admin.HireDate,
                Avatar = admin.Avatar,
                City = admin.City,
                Street = admin.Street,
                Number = admin.Number,
                NumberBox = admin.NumberBox,
                ZipCode = admin.ZipCode,
                Country = admin.Country,
                GSM = admin.GSM,
                BirthDate = admin.BirthDate
            };
        }

        internal static G.Admin ToLoginGlobal(this C.Admin admin)
        {
            return new G.Admin()
            {
                Email = admin.Email,
                Password = admin.Password
            };
        }

        internal static C.Admin ToClient(this G.Admin admin)
        {
            if (admin == null)
                return null;
            return new C.Admin(
                admin.AdminId,
                admin.StartDate,
                admin.EndDate,
                admin.EmployeeId,
                admin.FirstName,
                admin.LastName,
                admin.Email,
                admin.Password,
                admin.RegNat,
                admin.HireDate,
                admin.Active,
                admin.Avatar,
                admin.City,
                admin.Street,
                admin.Number,
                admin.NumberBox,
                admin.ZipCode,
                admin.Country,
                admin.GSM,
                admin.BirthDate);
        }

        internal static C.Admin ToLoginClient(this G.Admin admin)
        {
            if (admin == null)
                return null;
            return new C.Admin(admin.EmployeeId, admin.Email, admin.AdminId);
        }
        #endregion

        #region EmployeeMapper
        // Client Employee to Global Employee
        internal static G.Employee ToGlobal(this C.Employee entity)
        {
            return new G.Employee()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Password = entity.Password,
                RegNat = entity.RegNat,
                HireDate = entity.HireDate,
                Active = entity.Active,
                Avatar = entity.Avatar,
                City = entity.City,
                Street = entity.Street,
                Number = entity.Number,
                NumberBox = entity.NumberBox,
                ZipCode = entity.ZipCode,
                Country = entity.Country,
                GSM = entity.GSM,
                BirthDate = entity.BirthDate
            };
        }

        // Global Employee to Client Employee
        internal static C.Employee ToClient(this G.Employee entity)
        {
            if (entity == null)
                return null;
            return new C.Employee(
                entity.Id,
                entity.LastName,
                entity.FirstName,
                entity.Email,
                entity.Password,
                entity.RegNat,
                entity.HireDate,
                entity.Active,
                entity.Avatar,
                entity.City,
                entity.Street,
                entity.Number,
                entity.NumberBox,
                entity.ZipCode,
                entity.Country,
                entity.GSM,
                entity.BirthDate);
        }

        internal static C.Employee ToLoginClient(this G.Employee emp)
        {
            if (emp == null)
                return null;
            return new C.Employee(emp.Id, emp.Email);
        }
        #endregion

        #region EmployeeStateMapper
        internal static C.EmployeeState ToClient(this G.EmployeeState employeeState)
        {
            if (employeeState == null)
                return null;
            return new C.EmployeeState(
                employeeState.Id,
                employeeState.Name
                );
        }

        internal static G.EmployeeState ToGlobal(this C.EmployeeState employeeState)
        {
            if (employeeState == null)
                return null;
            return new G.EmployeeState
            {
                Id = employeeState.Id,
                Name = employeeState.Name
            };
        }

        internal static C.Employee_EmployeeState ToClient(this G.Employee_EmployeeState employeeState)
        {
            if (employeeState == null)
                return null;
            return new C.Employee_EmployeeState(
                employeeState.Id,
                employeeState.EmployeeId,
                employeeState.EmployeeStateId,
                employeeState.StartDate,
                employeeState.EndDate
                );
        }

        internal static G.Employee_EmployeeState ToGlobal(this C.Employee_EmployeeState employeeState)
        {
            if (employeeState == null)
                return null;
            return new G.Employee_EmployeeState
            {
                Id=employeeState.Id,
                EmployeeId=employeeState.EmployeeId,
                EmployeeStateId = employeeState.EmployeeStateId,
                StartDate = employeeState.StartDate,
                EndDate = employeeState.EndDate
            };
        }
        #endregion

        #region DepartementMapper
        internal static G.Department ToGlobal(this C.Department departement)
        {
            if (departement == null)
                return null;
            return new G.Department()
            {
                Id = departement.Id,
                Name = departement.Name,
                Description = departement.Description,
                AdminId = departement.AdminId
            };
        }

        internal static C.Department ToClient(this G.Department departement)
        {
            if (departement == null)
                return null;
            return new C.Department(
                departement.Id,
                departement.Name,
                departement.Description,
                departement.AdminId);
        }
        #endregion

        #region ProjectMapper
        internal static G.Project ToGlobal(this C.Project project)
        {
            return new G.Project()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                AdminId = project.AdminId,
                ProjectManager = project.ProjectManager
                
            };
        }
        
        internal static C.Project ToClient(this G.Project project)
        {
            if(project==null)
                return null;
            return new C.Project(
                project.Id,
                project.Name,
                project.Description,
                project.StartDate,
                project.EndDate,
                project.AdminId,
                project.ProjectManager);
        }
        #endregion

        #region EventMapper
        internal static G.Event ToGlobal(this C.Event events)
        {
            return new G.Event()
            {
                Id = events.Id,
                Name = events.Name,
                Description = events.Description,
                City = events.City,
                Street = events.Street,
                Number = events.Number,
                NumberBox = events.NumberBox,
                ZipCode = events.ZipCode,
                Country = events.Country,
                StartDate = events.StartDate,
                EndDate = events.EndDate,
                FullDay = events.FullDay,
                EmployeeId = events.EmployeeId

            };
        }




        internal static C.Event ToClient(this G.Event events)
        {
            return new C.Event(
                events.Id,
                events.Name,
                events.Description,
                events.City,
                events.Street,
                events.Number,
                events.NumberBox,
                events.ZipCode,
                events.Country,
                events.StartDate,
                events.EndDate,
                events.FullDay,
                events.EmployeeId);
        }




        #endregion
        #region MessageMapper
        internal static C.Message ToClient(this G.Message message)
        {
            if (message==null)
            {
                return null;
            }
            return new C.Message(
                message.Id,
                message.Title,
                message.Date,
                message.Text,
                message.EmployeeId);
        }

        internal static G.Message ToGlobal(this C.Message message)
        {
            if (message == null)
            {
                return null;
            }
            return new G.Message
            {
                Id = message.Id,
                Title = message.Title,
                Date = message.Date,
                Text = message.Text,
                EmployeeId = message.EmployeeId
            };
        }
        #endregion
        #region TaskMapper
        internal static G.Task ToGlobal(this C.Task task)
        {
            if (task == null)
                return null;
            return new G.Task
            {
                Id = task.Id,
                Name= task.Name,
                Description=task.Description,
                StartDate=task.StartDate,
                DeadLine = task.DeadLine,
                ProjectId = task.ProjectId,
                TaskTeam = task.TaskTeam,
                MainTaskId = task.MainTaskId
            };
        }

        internal static C.Task ToClient(this G.Task task)
        {
            if (task == null)
                return null;
            return new C.Task(
                task.Id,
                task.Name,
                task.Description,
                task.StartDate,
                task.DeadLine,
                task.ProjectId,
                task.TaskTeam,
                task.MainTaskId);
        }

        #region TaskStateMapper
        internal static C.TaskState ToClient(this G.TaskState taskState)
        {
            if (taskState == null)
                return null;
            return new C.TaskState(
                taskState.Id,
                taskState.Name);
        }

        internal static G.TaskState ToGlobal(this C.TaskState taskState)
        {
            if (taskState == null)
                return null;
            return new G.TaskState
            {
                Id = taskState.Id,
                Name = taskState.Name
            };
        }
        #endregion
        #endregion

        #region TeamMapper
        internal static G.Team ToGlobal(this C.Team team)
        { return new G.Team()
        {
            Id = team.Id,
            Name = team.Name,
            //CreateDate = team.CreateDate,
            ProjectId = team.ProjectId,
            TeamManagerId = team.TeamManagerId

            };



        }
        internal static C.Team ToClient(this G.Team team)
        {
            if (team == null)
                return null;
            return new C.Team(team.Id, team.Name, team.CreateDate, team.ProjectId,team.TeamManagerId);

        }


        #endregion

        #region InviteMapper

        internal static C.Invite ToClient(this G.Invite invite)
        {
            if (invite == null)
                return null;
            return new C.Invite(invite.EmployeeId,invite.EventId,invite.Present);
        }

        internal static G.Invite ToGlobal(this C.Invite invite)
        {
            if (invite == null)
                return null;
            return new G.Invite()
            {
                EmployeeId = invite.EmployeeId,
                EventId = invite.EventId,
                Present = invite.Present
            };
        }
        #endregion

        #region

        internal static G.PlanningItem ToGlobal(this C.PlanningItem planning)
        {
            return new G.PlanningItem()
            {
                Id = planning.Id,
                Name = planning.Name,
                StartDate = planning.StartDate,
                EndDate = planning.EndDate,
                EmployeeId = planning.EmployeeId,
                Type = planning.Type
            };
        }

        internal static C.PlanningItem ToClient(this G.PlanningItem planning)
        {
            return new C.PlanningItem(
                planning.Id,
                planning.Name,
                planning.StartDate,
                planning.EndDate,
                planning.EmployeeId,
                planning.Type
                );
        }
        #endregion
        #region DocumentMapper
        internal static G.Document ToGlobal(this C.Document document)
        {
            return new G.Document()
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                CreateDate = document.CreateDate,                
                Extention = document.Extention,
                EmployeeId = document.EmployeeId,
                FileBinId = document.FileBinId,
                OldFileId = document.OldFileId,
                Size = document.Size


            };

            //string name, string description, DateTime createDate,float size, string extention, int employeeId, int fileBinId

        }
        internal static C.Document ToClient(this G.Document document)
        {
            if(document==null)
                return null;
            return new C.Document()
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                CreateDate = document.CreateDate,
                Extention = document.Extention,
                EmployeeId = document.EmployeeId,
                FileBinId = document.FileBinId,
                OldFileId = document.OldFileId,
                Size = document.Size
            };
                

        }

        #endregion
        #region BinMapper
        internal static G.Bin ToGlobal(this C.Bin bin)
        {
            if (bin == null)
                return null;
            return new G.Bin()
            {
                Id = bin.Id,
                Binaries = bin.Binaries,
                UploadName =bin.UploadName,
                UploadDate = bin.UploadDate
                


            };

            //string name, string description, DateTime createDate,float size, string extention, int employeeId, int fileBinId

        }
        internal static C.Bin ToClient(this G.Bin bin)
        {
            if (bin == null)
                return null;
            return new C.Bin(bin.Id, bin.Binaries, bin.UploadName, bin.UploadDate);


        }

        #endregion

    }
}
