using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudaMaster.SharedModel
{
    public class CommonViewModel
    {
        
        public List<CategoryViewModel> CategoryList { get; set; }
        public List<SubCategoryViewModel> SubCategoryList { get; set; }
        public List<BrandViewModel> BrandList { get; set; }

    }
}
