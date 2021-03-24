using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public abstract class DBConfig
    {
        //internal const string InvariantName = "System.Data.SqlClient";//ConfigurationManager.ConnectionStrings["MSSQLConnection"].Providername;
        //internal const string ConnString = @"Data Source = FORMAVDI1610\TFTIC; Initial Catalog = RSE; Persist Security Info = True; User ID = devAccess; Password = tftic@2012";

        //internal const string InvariantName = "System.Data.SqlClient";//ConfigurationManager.ConnectionStrings["MSSQLConnection"].Providername;
        //internal const string ConnString = @"Data Source=DELL-SAM;Initial Catalog=RSE;Persist Security Info=True;User ID=sa;Password=********";

        internal const string InvariantName = "System.Data.SqlClient";//ConfigurationManager.ConnectionStrings["MSSQLConnection"].Providername;
        internal const string ConnString = @"Data Source=ASUSZAIDI;Initial Catalog=RSE;Integrated Security=True";
    }
}
