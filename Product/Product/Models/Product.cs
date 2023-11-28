using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName ="varchar(50)")]
        [DisplayName("Product Name")]
        [Required(ErrorMessage ="This field is required")]
        public string ProductName { get; set; }


        
       
    }
}
