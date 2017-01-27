using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace SaudaMaster.SharedModel
{
    public class StoreViewModel
    {
        public int StoreID { get; set; }

        [Required]
        [DisplayName("Store Name")]
        public string StoreName { get; set; }

        public string StoreLogo { get; set; }

        public List<StoreViewModel> StoreList { get; set; }
    }
}
