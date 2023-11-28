using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class State : BaseEntityClass
    {
        public string StateName { get; set; }   
        public int CountryId { get; set; }

        [JsonIgnore]
        public Country Country { get; set; }
        public IList<City> City { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
