using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class Country : BaseEntityClass
    {
        public string CountryName { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<State> State { get; set; }
    }
}
