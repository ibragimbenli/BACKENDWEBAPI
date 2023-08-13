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
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        Task<TEntity> InsertAsync(TEntity entitiy);
        Task UpdateAsync(TEntity entitiy);
        Task DeleteAsync(TEntity entitiy);
    }
}
