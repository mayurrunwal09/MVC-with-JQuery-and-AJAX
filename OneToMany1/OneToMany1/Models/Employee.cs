using System.ComponentModel.DataAnnotations;

namespace OneToMany1.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Location { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Gender { get; set; }
        public string State { get;set; }
        public string Country { get;set; }
        public int PostalCode { get;set; }
        public string Education { get;set; }

        public Department Department { get; set; }
        public int DepId { get;set; }
    }
}
