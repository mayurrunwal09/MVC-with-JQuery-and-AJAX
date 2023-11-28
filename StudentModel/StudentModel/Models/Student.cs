using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentModel.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [DisplayName("Student Name")]
        [Required(ErrorMessage ="This Field is required")]
        public string StudentName { get; set; }

        [DisplayName("Student Age")]
        [Required(ErrorMessage ="This Field is required")]
        public int StudentAge { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage ="This field is required")]
        public int Gender { get;set; }

        [Column(TypeName ="nvarchar(50)")]
        [Required(ErrorMessage ="This filed is required")]
        public string Address { get;set; }


        
        public string Contactno { get;set; }    

    }
}
