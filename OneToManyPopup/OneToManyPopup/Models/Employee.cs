using System.ComponentModel.DataAnnotations;

namespace OneToManyPopup.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get;set; }
        public string EmpName { get; set; }
        public string Location { get;set; }
        public DateTime DateOfJoining { get;set; }

        public Department Department { get;set; }
        public int DepId { get;set; }
    }
}
