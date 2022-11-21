

using Microsoft.EntityFrameworkCore;

namespace Institute.DAL.Core
{
    public abstract class RepositoryBase
    {
        private readonly DbContext dbContext;
        private readonly DbSet<TEntity> entities;
        public RepositoryBase(IDbFactory dbFactory)
        {
            this.dbContext = dbFactory.GetDbContext;
            this.entities = this.dbContext.Set<TEntity>();
        }

        public TEntity GetEntity(int entityid) => this.entities.Find(entityid);
    }
}
