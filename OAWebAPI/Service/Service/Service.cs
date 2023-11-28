using Domain;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class Service<T>:IService<T> where T : BaseEntity
    {
        #region Properties Value
        private readonly IRepository<T> _repository;
        #endregion
        #region Constructor
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        #endregion
      
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
        public T Get(int id)
        {
            return _repository.Get(id);
        }
        public void Insert(T entity)
        {
             _repository.Insert(entity);
        }

        public void Update(T entity)
        {
           _repository.Update(entity);
        }
        public void Delete(int id)
        {
            T entity = Get(id);
            _repository.Remove(entity);
            _repository.Delete(entity);
        }
       
    }
}
