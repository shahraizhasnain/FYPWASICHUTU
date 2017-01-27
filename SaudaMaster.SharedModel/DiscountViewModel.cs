using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace SaudaMaster.SharedModel
{
  public class DiscountViewModel
    {
        public int ItemID { get; set; }
        [Required]


        public decimal ItemDiscountPercentage { get; set; }


    }
}
