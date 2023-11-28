using Domain;
using Microsoft.EntityFrameworkCore;
using Repository_And_Services.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Repository
{
    public class Repository<T> : IRepositroy<T> where T : BaseEntityClass
    {
        private readonly MainDBContext _dbContext;
        private readonly DbSet<T> entities;

        public Repository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();   
        }
        public async Task<bool> Delete(T entity)
        {
            entities.Remove(entity);
            var res = await _dbContext.SaveChangesAsync();
            if(res>0)
            {
                    return true;
            }
            return false;
        }

        public async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await entities.FirstOrDefaultAsync(match);
        }

        public async Task<IList<T>> FindAll(Expression<Func<T, bool>> match)
        {
            return await entities.Where(match).ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await entities.FindAsync(id);
                }

        public async Task<IList<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<bool> Insert(T entity)
        {
            await entities.AddAsync(entity);
            var res = await _dbContext.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Update(T entity)
        {
            entities.Update(entity);
            var res = await _dbContext.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}
