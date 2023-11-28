using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.DepartmentServices
{
    public  interface IDepartmentService
    {
        Task<IList<DepartmentViewModel>> GetAll();
        Task<DepartmentViewModel> GetById(int id);
        Task<bool> Insert(InsertDepartment insertDepartment);
        Task<bool> Update(UpdateDepartment updateDepartment);
        Task<bool> DeleteById(int id);
        Task<Department> Find(Expression<Func<Department, bool>> predicate);
    }
}
