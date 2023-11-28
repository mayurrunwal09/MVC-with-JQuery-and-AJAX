using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get;set; }

        [Column(TypeName ="nvarchar(20)")]
        [DisplayName("Employee Name")]
        [Required(ErrorMessage ="This Field id required")]
        public string EmpName { get;set; }

        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Location")]
        [Required(ErrorMessage = "This Field id required")]
        public string Location { get;set; }
    
        public int DepId { get;set; }
    }
}
