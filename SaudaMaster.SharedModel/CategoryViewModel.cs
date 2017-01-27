using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel;
using System.Web.Mvc;


namespace SaudaMaster.SharedModel
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
		[ForeignKey("StoreID")]
        public int StoreID { get; set; }



        [Required]
		[DataType(DataType.Text)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [Required]
		[DataType(DataType.Text)]
        [DisplayName("Category Title")]
        public string CategoryDisplayName { get; set; }

     
        public string CategoryImage { get; set; }

     public List<CategoryViewModel> CategoryList { get; set; }
    }
    
}
