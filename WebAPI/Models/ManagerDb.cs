using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ManagerDb
    {
        [Key]
        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string ManagingDepartment { get; set; }

    }
}
