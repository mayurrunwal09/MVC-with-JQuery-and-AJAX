using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ItemImages : BaseEntity
    {
        public Guid ItemId { get; set; }

        public string ItemImage { get; set; }

        public virtual Item Item { get; set; }
    }
}
