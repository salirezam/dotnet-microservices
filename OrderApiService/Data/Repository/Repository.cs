using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class Repository<TEntity, TContext>: IRepository<TEntity>
        where TEntity: class, IEntity
        where TContext: DbContext
    {
        protected readonly DbSet<TEntity> dbSet;
        protected readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
                return null;

            dbSet.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
