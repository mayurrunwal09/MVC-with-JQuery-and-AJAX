using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Item
    {
       
       public string ItemCode { get; set; }
        
        public string ItemName { get; set; }
        public double Price { get; set; }

        public Guid CatagoryId { get; set; }

        public virtual IList<ItemImages> ItemImages { get; set; }
        public virtual SupplierItem SupplierItem { get; set; }
        public virtual CustomerItem CustomerItem { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}
