using System.Collections.Generic;
using System.Linq.Expressions;

namespace Finanzauto.Dominio.Common
{
    /// <summary>
    /// Generic base interface to implement on repository Base
    /// </summary>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity?> GetByParams(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        void Clear();
    }
}