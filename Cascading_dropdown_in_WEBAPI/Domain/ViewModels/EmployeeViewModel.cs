using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public  class EmployeeViewModel
    {
        public int Id { get; set; } 
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public int DepId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        public string DepName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }   
        public string CityName { get; set; }    

        public IList<Department> departments { get; set; } = new List<Department>();
        public IList<Country> countries { get; set; } = new List<Country>();
        public IList<State> states { get; set; }   = new List<State>();
        public IList<City> citys { get; set; } = new List<City>();

    }
    public class InsertEmployee
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public int DepId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
       
    }
    public class UpdateEmployee : InsertEmployee
    {
        public int Id { get; set; }
    }
}
