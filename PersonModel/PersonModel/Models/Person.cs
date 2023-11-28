using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace PersonModel.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get;set; }

        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Person Name")]
        [Required(ErrorMessage = "This Field id required")]
        public string personName { get;set; }

        [DisplayName("Person Age")]
        [Required(ErrorMessage ="This Field is required")]
        public int PersonAge { get;set; }

        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Person Gender")]
        [Required(ErrorMessage = "This Field id required")]
        public string Gender { get;set; }

        [DisplayName("Person Contact no")]
        [Required(ErrorMessage = "This field is required")]
        public string Contactno { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Person Location")]
        [Required(ErrorMessage = "This Field id required")]
        public string Location { get;set; }
    }
}
