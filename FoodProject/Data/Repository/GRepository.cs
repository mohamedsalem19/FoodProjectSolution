using FoodProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FoodProject.Data.Repository
{
    public class GRepository<Entity> : IGRepository<Entity> where Entity : BaseModel
    {
        Context _context;
        DbSet<Entity> _entities;
        public GRepository(Context context)
        {
            _context = context;

            _entities = _context.Set<Entity>();
        }
        public void Add(Entity entity)
        {
            entity.CreatedOn = DateTime.Now;
            // entity.CreatedBy = UserId;
            _entities.Add(entity);
        }
        public void SaveInclude(Entity entity, params string[] properties)
        {
            var local = _entities.Local.FirstOrDefault(x => x.Id == entity.Id);
            EntityEntry entry = null;
            if (local == null)
            {
                entry = _context.Entry(entity);
            }
            else
            {
                entry = _context.ChangeTracker.Entries<Entity>()
                    .FirstOrDefault(x => x.Entity.Id == entity.Id);
            }
            foreach (var property in entry.Properties)
            {
                if (properties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }

            }


        }

        public void Delete(Entity entity)
        {
            entity.IsDeleted = true;
            SaveInclude(entity, nameof(BaseModel.IsDeleted));
        }
        public void HardDelete(Entity entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> predicate)
        {
            return _entities.Where(x => x.IsDeleted == false).Where(predicate);
        }

        public IQueryable<Entity> GetAll()
        {
            return _entities.Where(x => x.IsDeleted == false);
        }
        public IQueryable<Entity> GetAllWithDeleted()
        {
            return _entities;
        }

        public Entity GetById(int id)
        {
            return Get(x => x.Id == id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
