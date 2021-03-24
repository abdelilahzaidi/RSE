using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DB;

namespace Model.Global.Service
{
    public class BinService  :DBConfig,IBinRepository<Bin,int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bin> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Get_FileFileBinary", true);
            Func<IDataRecord, Bin> convert = (reader) => reader.ToBin();
            return connection.ExecuteReader<Bin>(command, convert);
        }

        public Bin Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Get_FileFileBinaryById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, Bin> convert = (reader) => reader.ToBin();
            return connection.ExecuteReader<Bin>(command, convert).SingleOrDefault();
        }

        public Bin Insert(Bin entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Insert_FileBinary", true);
            command.AddParameter("Bin", entity.Binaries);
            command.AddParameter("UploadName", entity.UploadName);
            entity.Id = (int)connection.ExecuteScalar(command);
            return entity;

        }

        public bool Update(Bin entity)
        {
            throw new NotImplementedException();
        }
    }
}
