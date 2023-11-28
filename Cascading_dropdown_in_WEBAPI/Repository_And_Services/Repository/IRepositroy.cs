using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Repository
{
    public  interface IRepositroy<T>
    {
        Task<IList<T>> GetAll();    
        Task<T> Get(int id);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Find(Expression<Func<T, bool>> match);
        Task<IList<T>> FindAll(Expression<Func<T, bool>> match);
    }
}
