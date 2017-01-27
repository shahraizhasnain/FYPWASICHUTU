using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace SaudaMaster.SharedModel
{
    public class BrandViewModel
    {
        public int BrandID { get; set; }

        [Required]
        [DisplayName("Brand Name")]
        public string BrandName { get; set; }

        [Required]
        [DisplayName("Brand Title")]
        public string BrandTitle { get; set; }

        [Required]
        [DisplayName("Brand Description")]
		[StringLength(50, ErrorMessage = "Description cannot be longer than 10 characters.")]
        public string BrandDescription { get; set; }


        //[Required]
        public string BrandImage { get; set; }
	
        public List<BrandViewModel> BrandList { get; set; }
    }
}
