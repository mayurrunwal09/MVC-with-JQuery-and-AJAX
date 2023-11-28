using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Generic
{
    public  interface IService<T>
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<IList<T>> FindAll(Expression<Func<T, bool>> predicate);
    }
}
