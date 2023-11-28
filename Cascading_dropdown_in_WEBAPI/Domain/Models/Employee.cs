using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class Employee : BaseEntityClass
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
        [JsonIgnore]
        public Department Department { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }
}
