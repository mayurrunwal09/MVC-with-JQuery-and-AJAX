using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Please Enter UserId...!")]
        [RegularExpression(@"(?:\s|^)#[A-Za-z0-9]+(?:\s|$)", ErrorMessage = "UserID start with # and Only Number and character are allowed eg(#User1001)")]
        [StringLength(10)]
        public int UserId { get; set; }

        [Required(ErrorMessage ="This Field is required")]
        [DisplayName("User Name")]
        [StringLength(100)]
        public int UserName { get;set; }
        [Required(ErrorMessage = "This Field is required")]
        [DisplayName("Password")]
        [StringLength(100)]
        public string Password { get;set; }
        [Required(ErrorMessage = "This Field is required")]
        [DisplayName("User Email")]
        [StringLength(100)]
        public string Email { get;set; }
        [Required(ErrorMessage = "This Field is required")]   
        [DisplayName("Location")]
        [StringLength(100)]
        public string Location { get;set; }
        public string Picture { get;set; }

        public Guid UserTypeId { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }
        public virtual IList<SupplierItem> Suppliers { get; set; }  
        public virtual IList<CustomerItem> CustomerItems { get; set; }

        

    }
}
