using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DAL.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(DbContext dbContext)
        {
            this._context = dbContext;
            this._entities = this._context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter) => this._entities.Any(filter);

        public virtual IEnumerable<TEntity> GetEntities() => this._entities;

        public virtual TEntity GetEntity(int entityid) => this._entities.Find(entityid);

        public virtual void Remove(TEntity entity) => this._entities.Remove(entity);

        public virtual void Save(TEntity entity)
        {
            this._entities.Add(entity);
            this._context.SaveChanges();
        }

        public virtual void Save(TEntity[] entities)
        {
            this._entities.AddRange(entities);
            this._context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this._entities.Update(entity);
            this._context.SaveChanges();
        }
    }
}
