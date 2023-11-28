using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public  class DepartmentViewModel
    {
        public int Id { get; set; }
        public string DepName { get; set; }
    }
    public class InsertDepartment
    {
        public string DepName { get; set; }
    }
    public class UpdateDepartment : InsertDepartment
    {
        public int Id { get; set; }
    }
}
