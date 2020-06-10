using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class customerdb
    {
        [Key]
        public int cust_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int contact { get; set; }
        public string address { get; set; }
    }
}
