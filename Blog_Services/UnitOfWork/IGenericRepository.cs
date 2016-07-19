using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.UnitOfWork
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        TEntity GetByID(object id);
        void Insert(TEntity entityToInsert);

        void Update(TEntity entityToUpdate);

        #region Async version

        Task Delete(object id);

        Task Delete(TEntity entityToDelete);

        Task<TEntity> GetByIdAsync(object id);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entityToUpdate);
        #endregion

    }
}
