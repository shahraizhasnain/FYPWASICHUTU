using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace SaudaMaster.SharedModel
{
    public class StoreApiModel
    {
        public List<StoreViewModel> StoreList { get; set; }
    }
}
