using System.Linq.Expressions;

namespace FoodProject.Data.Repository
{
    public interface IGRepository<Entity>
    {
        void Add(Entity entity);

        void SaveInclude(Entity entity, params string[] properties);

        void Delete(Entity entity);
        void HardDelete(Entity entity);

        IQueryable<Entity> GetAll();
        IQueryable<Entity> GetAllWithDeleted();

        IQueryable<Entity> Get(Expression<Func<Entity, bool>> predicate);

        Entity GetById(int id);

       


    }
}
