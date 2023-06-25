using Ah.Model;

namespace CommonTypesLayer.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity> 
        where TEntity :class, IEntity
    {
        //CRUD işelemlerini gerçekleştirmek için oluşuturulan Interface...
        List<TEntity> GetAll();
        TEntity Get();
        void Insert(TEntity entitiy);
        void Update(TEntity entitiy);
        void Delete(TEntity entitiy);
    }
}
