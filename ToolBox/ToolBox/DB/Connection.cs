using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DB
{
    public class Connection
    {
        #region Props
        public string InvariantName { get; set; }
        private string ConnectionString { get; set; }
        private DbProviderFactory Factory { get; set; }
        #endregion
        #region Ctor
        public Connection(string invariantName, string connectionString) {
            InvariantName = invariantName;
            ConnectionString = connectionString;
            Factory = DbProviderFactories.GetFactory(InvariantName);
            using (DbConnection conn = CreateConnection()) {
                conn.Open();
            }
        }
        #endregion
        #region Methods
        private DbConnection CreateConnection()
        {
            DbConnection conn = Factory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            return conn;
        }

        private DbCommand CreateCommand(DbConnection conn,Command command)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandType = (command.IsStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;
            cmd.CommandText = command.Query;
            foreach(KeyValuePair<string,object> keyValue in command.Parameters)
            {
                DbParameter param = Factory.CreateParameter();
                param.ParameterName = keyValue.Key;
                param.Value = (keyValue.Value == null)?DBNull.Value:keyValue.Value;
                cmd.Parameters.Add(param);
            }
            return cmd;
        }

        public int ExecuteNonQuery(Command command) {
            using (DbConnection conn = this.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = this.CreateCommand(conn,command))
                {  
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public object ExecuteScalar(Command command) {
            using (DbConnection conn = this.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = this.CreateCommand(conn,command))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
        public IEnumerable<T> ExecuteReader<T>(Command command, Func<IDataReader, T> func) where T : new()
        {
            using(DbConnection conn = this.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = this.CreateCommand(conn,command))
                {
                    DbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return func(reader);       
                    }
                }
            }
        }
        #endregion
    }
}
