using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

using Blog_Entity;

namespace Blog_Services.UnitOfWork
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {

        public BlogEntityContext context;
        public DbSet<TEntity> dbSet;

        public GenericRepository(BlogEntityContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)

        {
            ParallelQuery<TEntity> query = dbSet.AsParallel<TEntity>();

            if (filter != null)
            {
                query = ParallelEnumerable.Where<TEntity>(query, filter.Compile());
            }

            if (orderBy != null)
            {
                return orderBy(query.AsQueryable());
            }
            else
            {
                return query.AsQueryable<TEntity>();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }


        public void Insert(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public async Task InsertAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();
        }



        public async Task Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            await Delete(entityToDelete);

            await context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await Delete(entityToDelete);

            await context.SaveChangesAsync();
        }



        public void Update(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;

            context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
