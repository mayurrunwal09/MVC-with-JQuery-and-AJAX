using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class Department : BaseEntityClass
    {
        public string DepName { get; set; }

        [JsonIgnore] 
        public IList<Employee> Employees { get; set; }

    }
}
