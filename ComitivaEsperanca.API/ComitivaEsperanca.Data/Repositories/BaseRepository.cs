using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace ComitivaEsperanca.API.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public CoreContext CoreContext { get; }

        public BaseRepository(CoreContext context)
        {
            CoreContext = context;
        }

        public void Add(TEntity entity)
        {
            CoreContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            CoreContext.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return CoreContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return CoreContext.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public void Update(TEntity entity)
        {
            CoreContext.Set<TEntity>().Update(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return CoreContext.Set<TEntity>().Where(predicate).FirstOrDefault();
        }
    }
        

}
