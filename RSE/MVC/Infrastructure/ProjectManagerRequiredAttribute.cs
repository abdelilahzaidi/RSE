using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ProjectManagerRequiredAttribute : AuthorizeAttribute
    {
        protected int ProjectId { get; set; }

        public ProjectManagerRequiredAttribute()
        {
            int projectId = 0;
            if (Int32.TryParse(HttpContext.Current.Request.Url.Segments.Last(), out projectId))
                ProjectId = projectId;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)//on verifie si le user n'est pas null(cf authcontroller-> login)
        {
            bool isProjectManager = false;
            if (UserSession.CurrentUser != null)
            {
                ProjectService repoProject = new ProjectService();
                if (UserSession.CurrentUser.Id == repoProject.Get(ProjectId).ProjectManager)
                    isProjectManager = true;                
            }
            return (isProjectManager);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)//guide le user si non autorisé
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Project", Action = "Details", Id = ProjectId}));

        }


        
    }
}