using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client
{
    public class IdComparer<TEntity> : IEqualityComparer<TEntity> where TEntity : IDataObject
    {

        public bool Equals(TEntity x, TEntity y)
        {
            return (Int32.Equals(x.Id, y.Id));
        }        

        public int GetHashCode(TEntity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
