using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? UpdatedOn { get;set; }

        [DefaultValue(true)]
        [DisplayName("Active")]
        public bool? IsActive { get; set; }
    }
}
