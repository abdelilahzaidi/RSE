using System;
using System.Collections.Generic;
using System.Text;
using Model.Global.Data;

namespace Model.Global
{
    public interface IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> Get();
        TEntity Insert(TEntity entity);
        TEntity Get(TKey Id);
        bool Update(TEntity entity);
        //bool Update(int id, TEntity entity);
        bool Delete(TKey id);
        
    }
}
