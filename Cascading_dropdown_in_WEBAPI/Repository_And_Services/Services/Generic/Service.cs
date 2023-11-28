using Domain;
using Repository_And_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Generic
{
    public class Service<T> : IService<T> where T : BaseEntityClass
    {
        private readonly IRepositroy<T> _repositroy;
        public Service(IRepositroy<T> repositroy)
        {
            _repositroy = repositroy;
        }
        public async Task<bool> Delete(T entity)
        {
            return await _repositroy.Delete(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return await _repositroy.Find(predicate);
        }

        public async Task<IList<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await _repositroy.FindAll(predicate);
        }

        public Task<IList<T>> GetAll()
        {
            return _repositroy.GetAll();
        }

        public Task<T> GetById(int id)
        {
            return _repositroy.Get(id);
        }

        public Task<bool> Insert(T entity)
        {
            return _repositroy.Insert(entity);
        }

        public Task<bool> Update(T entity)
        {
            return _repositroy.Update(entity);
        }
    }
}
