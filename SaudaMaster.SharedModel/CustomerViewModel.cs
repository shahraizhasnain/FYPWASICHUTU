using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SaudaMaster.SharedModel
{
    public class CustomerViewModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerContact { get; set; }
        [Required]
        public string CustomerAddress1 { get; set; }
    }
}
