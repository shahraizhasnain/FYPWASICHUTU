using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Adapter;
using SaudaMaster.SharedModel;


namespace SaudaMaster.Services
{
    public class SubCategoryServices : ISubCategoryService
    {
        SubCategoryAdapter subcategoryadapter;
        CategoryAdapter categoryadapter;
        public SubCategoryServices()
        {
            this.subcategoryadapter = new SubCategoryAdapter();
            this.categoryadapter = new CategoryAdapter();
        }

        public IEnumerable<SubCategoryViewModel> ReturnAllSubCategory(int store)
        {
            return subcategoryadapter.ReturnAllSubCategory(store);
        }
        public IEnumerable<SubCategoryViewModel> ReturnAllSubCategoriesw(int categoryID)
        {
            return subcategoryadapter.ReturnAllSubCategoryw(categoryID);
        }

        public void CreateSubCategory(SubCategoryViewModel subcategoryViewModel)
        {
            subcategoryadapter.CreateSubCategory(subcategoryViewModel);
        }

        public IEnumerable<CategoryViewModel> ReturnAllCategories(int store)
        {
            return categoryadapter.ReturnAllCategories(store);
        }

        public void EditSubCategory(SubCategoryViewModel subCategoryViewModel)
        {
            subcategoryadapter.EditSubCategory(subCategoryViewModel);
        }

        public SubCategoryViewModel EditSubCategory(int SubCategoryID)
        {
            return subcategoryadapter.EditSubCategory(SubCategoryID);
        }

        public void DeleteSubCategory(int subcategoryID)
        {
            subcategoryadapter.DeleteSubCategory(subcategoryID);
        }
    }

    public interface ISubCategoryService
    {
        void CreateSubCategory(SubCategoryViewModel subcategoryViewModel);
        IEnumerable<SubCategoryViewModel> ReturnAllSubCategory(int store);
        IEnumerable<CategoryViewModel> ReturnAllCategories(int store);
        IEnumerable<SubCategoryViewModel> ReturnAllSubCategoriesw(int categoryID);
        void EditSubCategory(SubCategoryViewModel subCategoryViewModel);
        SubCategoryViewModel EditSubCategory(int SubCategoryID );
        //IEnumerable<SubCategoryViewModel> dropcategory();
        //BrandViewModel EditBrand(int BrandID);
        //void EditBrand(BrandViewModel brandViewModel);
        void DeleteSubCategory(int subcategoryID);
        //bool CheckDuplicate(BrandViewModel brand);
        //bool CheckDuplicateForUpdate(string brand, int id);
    }
}

