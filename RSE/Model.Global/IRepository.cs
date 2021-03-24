using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Global
{
    public interface IRepository<TEntity, TKey>
    {
        //IEnumerable<TEntity> Get();
        //TEntity Get(TKey id);
        TEntity Insert(TEntity entity);
        //bool Update(int id, TEntity entity);
        //bool Delete(TKey id);
    }
}
