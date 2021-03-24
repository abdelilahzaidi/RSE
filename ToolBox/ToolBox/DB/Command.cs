using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DB
{
    public class Command
    {
        #region Props
        public string Query { get; set; }
        public Dictionary<string,object> Parameters { get; set; }
        public bool IsStoredProcedure { get; set; } // procédure stocké connection.command.commandtype
        #endregion
        #region Ctor

        public Command(string query) : this(query,false)
        {

        }

        public Command(string query, bool proc) {
            if (string.IsNullOrWhiteSpace(query)) {
                throw new Exception();
                    }
            else {
                Query = query;
            }
            Parameters = new Dictionary<string, object>();
            IsStoredProcedure = proc;
        }
        #endregion
        #region Methods
        public void AddParameter(string Name, object Value) {
            Parameters.Add(Name, (Value == null)?DBNull.Value:Value);
        }
        #endregion 
    }
}
