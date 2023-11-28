using Domain.Models;
using Domain.ViewModels;
using Repository_And_Services.Repository;
using Repository_And_Services.Services.Custom.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositroy<Employee> _employeeRepository;

        public EmployeeService(IRepositroy<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                Employee employee = await _employeeRepository.Get(id);
                if (employee != null)
                {
                    var result = await _employeeRepository.Delete(employee);
                    return result;
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

        public async Task<EmployeeViewModel> GetById(int id)
        {
            var employee = await _employeeRepository.Get(id);
            if (employee == null)
            {
                return null;
            }

            var viewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeAge = employee.EmployeeAge,
                Email = employee.Email,
                Password = employee.Password,
                Phone = employee.Phone,
                DepId = employee.DepId,
                CountryId = employee.CountryId,
                StateId = employee.StateId,
                CityId = employee.CityId,
            };
            return viewModel;
        }

        public async Task<IList<EmployeeViewModel>> GetAll()
        {


            var employees = await _employeeRepository.GetAll();

            var employeeViewModels = employees.Select(employee => new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeAge = employee.EmployeeAge,
                Email = employee.Email,
                Password = employee.Password,
                Phone = employee.Phone,
                DepId = employee.DepId,
                CountryId = employee.CountryId,

                StateId = employee.StateId,
                CityId = employee.CityId,
                


            }).ToList();

            return employeeViewModels;
        }

        public async Task<bool> Insert(InsertEmployee insertEmployee)
        {
            try
            {
                // Check if an employee with the same EmployeeId already exists
                var existingEmployee = await _employeeRepository.Find(e => e.EmployeeId == insertEmployee.EmployeeId);
                if (existingEmployee != null)
                {
                    return false; // Employee with the same EmployeeId already exists
                }

                var newEmployee = new Employee
                {
                    EmployeeId = insertEmployee.EmployeeId,
                    EmployeeName = insertEmployee.EmployeeName,
                    EmployeeAge = insertEmployee.EmployeeAge,
                    Email = insertEmployee.Email,
                    Password = insertEmployee.Password,
                    Phone = insertEmployee.Phone,
                    DepId = insertEmployee.DepId,
                    CountryId = insertEmployee.CountryId,
                    StateId = insertEmployee.StateId,
                    CityId = insertEmployee.CityId,
                };

                var result = await _employeeRepository.Insert(newEmployee);
                return result;
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                // You can log the exception using your logger (_logger)
                return false; // Return false to indicate an error
            }
        }

        public async Task<bool> Update(UpdateEmployee updateEmployee)
        {
            var employee = await _employeeRepository.Get(updateEmployee.Id);
            if (employee != null)
            {
                employee.EmployeeId = updateEmployee.EmployeeId;
                employee.EmployeeName = updateEmployee.EmployeeName;
                employee.EmployeeAge = updateEmployee.EmployeeAge;
                employee.Email = updateEmployee.Email;
                employee.Password = updateEmployee.Password;
                employee.Phone = updateEmployee.Phone;
                employee.DepId = updateEmployee.DepId;
                employee.CountryId = updateEmployee.CountryId;
                employee.StateId = updateEmployee.StateId;
                employee.CityId = updateEmployee.CityId;

                var result = await _employeeRepository.Update(employee);
                return result;
            }
            else
            {
                return false; // Employee not found
            }
        }

        public Task<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            return _employeeRepository.Find(predicate);
        }
        
    }
}
