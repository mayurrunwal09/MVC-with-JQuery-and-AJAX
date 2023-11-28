using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool IsAdmin { get; set; }
        public string UserSalt { get; set; }


    }
}
