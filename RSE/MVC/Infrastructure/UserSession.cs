using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Infrastructure
{
    public static class UserSession
    {
        public static User CurrentUser {
            get { return (User)HttpContext.Current.Session["User"]; }
            set { HttpContext.Current.Session["User"] = value; }
        }
    }
}