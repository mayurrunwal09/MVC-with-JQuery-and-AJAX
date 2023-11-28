using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student : Base
    {
        public string StudentName { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Contactno { get;set; }
        public string Picture { get; set; }
    }
}
