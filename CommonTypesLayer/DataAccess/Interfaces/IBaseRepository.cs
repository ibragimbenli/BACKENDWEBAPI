using CommonTypesLayer.Model;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CommonTypesLayer.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
        //CRUD işelemlerini gerçekleştirmek için oluşuturulan Interface...
        //ctx....Include("Category","Employee","City","S..."
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        TEntity Insert(TEntity entitiy);
        void Update(TEntity entitiy);
        void Delete(TEntity entitiy);
    }
}
