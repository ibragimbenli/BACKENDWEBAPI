using CommonTypesLayer.DataAccess.Interfaces;
using CommonTypesLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;

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

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }

                return dbSet.SingleOrDefault(predicate);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            //delagate generic
            //func
            //act
            //pridicate
            //Expression<Func<Product>,bool>
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                if (predicate == null)
                    return dbSet.ToList();
                else
                    return dbSet.Where(predicate).ToList();
            }

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
