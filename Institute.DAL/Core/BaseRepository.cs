using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Institute.DAL.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
            _entities = _context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter) => _entities.Any(filter);

        public virtual IEnumerable<TEntity> GetEntities() => _entities;

        public virtual TEntity GetEntity(int entityid) => _entities.Find(entityid);

        public virtual void Remove(TEntity entity) => _entities.Remove(entity);

        public virtual void Save(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Save(TEntity[] entities)
        {
            _entities.AddRange(entities);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
