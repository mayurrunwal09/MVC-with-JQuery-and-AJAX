using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LoginUser:BaseEntity
    {
        public string UserPassword { get; set; }
        [DisplayFormat(DataFormatString="{00:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime UserLastLoginDateTime { get; set; }
        [System.ComponentModel.DefaultValue("127.0.0.1")]
        public string UserLastLoginIpAddress { get; set; }
    }
}
