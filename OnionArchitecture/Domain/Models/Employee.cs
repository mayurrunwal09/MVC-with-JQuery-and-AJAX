using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee : BaseEntity
    {
       
        public string EmpName { get;set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
