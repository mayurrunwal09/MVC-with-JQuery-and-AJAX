using Domain.Models;
using Domain.ViewModels;
using Repository_And_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositroy<Department> _repositroy;
       public DepartmentService(IRepositroy<Department> repositroy)
        {
            _repositroy = repositroy;
        }
        public async Task<bool> DeleteById(int id)
        {
            if (id != null)
            {
                Department department = await _repositroy.Get(id);
                if (department != null)
                {
                  _=  _repositroy.Delete(department);
                    
                        return true;                   
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Task<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            return _repositroy.Find(predicate); 
        }

        public async Task<IList<DepartmentViewModel>> GetAll()
        {
            IList<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
            IList<Department> departments = await _repositroy.GetAll();
            foreach(Department department in departments)
            {
                DepartmentViewModel viewmodel = new()
                {
                    Id = department.Id,
                    DepName = department.DepName,
                };
                departmentViewModels.Add(viewmodel);
            }
            return departmentViewModels;
        }

        public async Task<DepartmentViewModel> GetById(int id)
        {
            var res = await _repositroy.Get(id);
            if (res == null)
            {
                return null;
            }
            else
            {
                DepartmentViewModel viewModel = new()
                {
                    Id = res.Id,
                    DepName = res.DepName,
                };
                return viewModel;
            }
        }

        public Task<bool> Insert(InsertDepartment insertDepartment)
        {
            Department department = new()
            {
                DepName = insertDepartment.DepName,
            };
            return _repositroy.Insert(department);
        }

        public async Task<bool> Update(UpdateDepartment updateDepartment)
        {
            Department department = await _repositroy.Get(updateDepartment.Id);
            if (department != null)
            {
                department.DepName = updateDepartment.DepName;

                var res = await _repositroy.Update(department);
                return res;
            }
            else
            {
                return false;
            }
        }
    }
}
