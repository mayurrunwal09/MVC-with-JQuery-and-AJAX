using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Catagory : BaseEntity
    {
        [Required]
        public string CatagoryName { get; set; }

        public virtual IList<Item> Items { get; set; }
    }            
}
