using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.EmployeeServices
{
    public  interface IEmployeeService
    {
        Task<IList<EmployeeViewModel>> GetAll();
        Task<EmployeeViewModel> GetById(int id);
        Task<bool> Insert(InsertEmployee insertEmployee);
        Task<bool> Update(UpdateEmployee updateEmployee);
        Task<bool> Delete(int id);
        Task<Employee> Find(Expression<Func<Employee, bool>> predicate);
    }
}
