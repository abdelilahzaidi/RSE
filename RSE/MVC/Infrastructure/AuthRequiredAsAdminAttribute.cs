using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiredAsAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)//on verifie si le user n'est pas null(cf authcontroller-> login)
        {
            return (UserSession.CurrentUser != null && UserSession.CurrentUser.AdminId !=null);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)//guide le user si non autorisé
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Auth", Action = "Login"}));

        }


        
    }
}