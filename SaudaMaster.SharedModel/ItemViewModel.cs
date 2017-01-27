using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace SaudaMaster.SharedModel
{
    public class ItemViewModel
    {
        public int ItemID { get; set; }
        public int StoreID { get; set; }
        [ForeignKey("StoreID")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]

        public string CategoryName { get; set; }
        public int SubCategoryID { get; set; }
        [ForeignKey("SubCategoryID")]


        public string SubCategoryName { get; set; }

      
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public string BrandName { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [Required]
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }

        [Required]
        [DisplayName("Price")]
        public string ItemPrice { get; set; }

        [Required]
        [DisplayName("Item Availability")]
        public string ItemAvailability { get; set; }

        [Required]
        [DisplayName("Item Discount Percentage")]
        public decimal ItemDiscountPercentage { get; set; }

        public string ItemImage { get; set; }

        public List<ItemViewModel> ItemList { get; set; }
    }
}

