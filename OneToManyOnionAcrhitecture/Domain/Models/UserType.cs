using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserType : BaseEntity
    {
        
        public string UserTypeName { get; set; }


        public virtual IList<User> Users { get; set; }
        
       
    }
}
