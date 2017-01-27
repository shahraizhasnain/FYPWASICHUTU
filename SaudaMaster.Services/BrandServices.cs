using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Adapter;
using SaudaMaster.SharedModel;
namespace SaudaMaster.Services
{
    public class BrandServices : IBrandService
    {
        BrandAdapter brandAdapter;
        public BrandServices()
        {
            this.brandAdapter = new BrandAdapter();
        }  

        public IEnumerable<BrandViewModel> ReturnAllBrands()
        {
            return brandAdapter.ReturnAllBrands();
        }

        public void CreateBrand(BrandViewModel brandViewModel)
        {
            brandAdapter.CreateBrand(brandViewModel);
        }

        public BrandViewModel EditBrand(int BrandID)
        {
            return brandAdapter.EditBrand(BrandID);
        }

        public void EditBrand(BrandViewModel brandViewModel)
        {
            brandAdapter.EditBrand(brandViewModel);
        }

        public bool CheckDuplicate(string BrandName)
        {
            return brandAdapter.CheckDuplicate(BrandName);
        }

        public void DeleteBrand(int BrandID)
        {
            brandAdapter.DeleteBrand(BrandID);
        }
    }
    public interface IBrandService
    {
        void CreateBrand(BrandViewModel brandViewModel);
        IEnumerable<BrandViewModel> ReturnAllBrands();
        BrandViewModel EditBrand(int BrandID);
        void EditBrand(BrandViewModel brandViewModel);
        void DeleteBrand(int BrandID);
        //bool CheckDuplicate(BrandViewModel brand);
        bool CheckDuplicate(string BrandName);
    }
}
