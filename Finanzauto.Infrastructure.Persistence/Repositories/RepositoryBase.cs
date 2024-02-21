using Finanzauto.Dominio.Common;
using Finanzauto.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finanzauto.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Generic base class with the basic methods to be used by any service
    /// </summary>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// The dbcontext
        /// </summary>
        private readonly FinanzautoDBContext _dataContext;

        /// <summary>
        /// The entities general
        /// </summary>
        private readonly DbSet<TEntity> _entities;
        public RepositoryBase(FinanzautoDBContext dataContext)
        {
            _dataContext = dataContext;
            _entities = dataContext.Set<TEntity>();
        }
        public async Task<bool> Add(TEntity entity)
        {
            _entities.Add(entity);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            TEntity? entityDelete = _entities.Find(id);
            if (entityDelete != null)
            {
                _entities.Remove(entityDelete);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> Update(TEntity entity)
        {
            _entities.Update(entity);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public Task<IQueryable<TEntity>> GetAll()
        {
            return Task.FromResult(_entities.AsQueryable());
        }

        public async Task<TEntity?> GetByParams(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await GetAll();
            query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(where);
        }

        public void Clear()
        {
            _dataContext.ChangeTracker.Clear();
        }
    }
}
