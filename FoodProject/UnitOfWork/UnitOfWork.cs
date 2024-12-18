using FoodProject.Data;
using FoodProject.Data.Repository;
using FoodProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repsitory.Data;
using Talabat.Repsitory.Repositories;

namespace FoodProject.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;

        public UnitOfWork(Context dbContext)
        {
            _dbContext = dbContext;
            repoistories = new Hashtable();

        }
        Hashtable repoistories;

        public async Task<int> CompleteAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public IGRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel
        {
            var key = typeof(TEntity).Name;
            if (!repoistories.ContainsKey(key))
            {
                var repository = new GRepository<TEntity>(_dbContext);
                repoistories.Add(key, repository); 
            }
            return repoistories[key] as IGRepository<TEntity>  ;
           
        }
    }
}
