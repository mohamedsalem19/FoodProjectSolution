

using FoodProject.Data.Repository;
using FoodProject.Models;

namespace FoodProject.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable 
    {
        IGRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel; 
        Task<int> CompleteAsync();

    }
}
