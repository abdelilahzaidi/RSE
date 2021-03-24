using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD=Model.Client.Data;
using Model.Client.Mapper;
using Model.Global;
using GD = Model.Global.Data;
using GS = Model.Global.Service;

namespace Model.Client.Service
{
    public class BinService : IBinRepository<CD.Bin,int>
    {
        private IBinRepository<GD.Bin,int> RepositoryGlobal { get; set; }
        public BinService()
        {
            RepositoryGlobal = new GS.BinService();

        }
        public IEnumerable<CD.Bin> Get()
        {
            return RepositoryGlobal.Get().Select(t => t.ToClient());
        }

        public CD.Bin Get(int Id)
        {
            return RepositoryGlobal.Get(Id).ToClient();
        }
        public CD.Bin Insert(CD.Bin entity)
        {
            return RepositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public bool Update(CD.Bin entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
