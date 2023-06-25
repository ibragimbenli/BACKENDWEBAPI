using Ah.Model;
using CommonTypesLayer.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonTypesLayer.DataAccess.Implementaitons.EF
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        //CRUD işlemlerinin nasıl gerçekleşeceğini yazdığım sınıf
        public void Delete(TEntity entitiy)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Remove(entitiy);
            ctx.SaveChanges();
        }

        public TEntity Get()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            using var ctx = new TContext();

            return ctx.Set<TEntity>().ToList();
        }

        public void Insert(TEntity entitiy)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Add(entitiy);
            ctx.SaveChanges();
        }

        public void Update(TEntity entitiy)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Update(entitiy);
            ctx.SaveChanges();
        }
    }
}
