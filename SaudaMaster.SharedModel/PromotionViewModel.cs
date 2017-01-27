using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SaudaMaster.SharedModel
{
  public class PromotionViewModel
    {
        public int ItemID { get; set; }

        [Required]
        public string Promotion { get; set; }
    }
}
