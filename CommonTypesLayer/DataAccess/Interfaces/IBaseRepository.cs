using CommonTypesLayer.Model;
using System.Linq.Expressions;

namespace CommonTypesLayer.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity> 
        where TEntity :class, IEntity
    {
        //CRUD işelemlerini gerçekleştirmek için oluşuturulan Interface...
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entitiy);
        void Update(TEntity entitiy);
        void Delete(TEntity entitiy);
    }
}
