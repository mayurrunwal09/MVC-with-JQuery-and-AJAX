using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class City:BaseEntityClass
    {
        public string CityName { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
