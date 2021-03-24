using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public interface IDataObject
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}