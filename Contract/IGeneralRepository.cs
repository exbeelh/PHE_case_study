using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManagement.Contract
{
    public interface IGeneralRepository<TEntity, Type>
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Type id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
