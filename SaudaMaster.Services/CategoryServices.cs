using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Adapter;
using SaudaMaster.SharedModel;

namespace SaudaMaster.Services
{
    public class CategoryServices : ICategoryService
    {
        CategoryAdapter CategoryAdapter;
        public CategoryServices()
        {
            this.CategoryAdapter = new CategoryAdapter();
        }


        public IEnumerable<CategoryViewModel> ReturnAllCategories(int store)
        {
            return CategoryAdapter.ReturnAllCategories(store);
        }


        public void CreateCategory(CategoryViewModel CategoryViewModel)
        {
            CategoryAdapter.CreateCategory(CategoryViewModel);
        }

        public void Delete(int CategoryID)
        {
            CategoryAdapter.DeleteCategory(CategoryID);
        }

        public CategoryViewModel EditCategory(int CategoryID)
        {
            return CategoryAdapter.EditCategory(CategoryID);
        }

        public void EditCategory(CategoryViewModel CategoryViewModel)
        {
            CategoryAdapter.EditCategory(CategoryViewModel);
        }
		
		public bool CheckDuplicate(string Categoryname, int storeid)			
	        {			
	            return CategoryAdapter.CheckDuplicate(Categoryname, storeid);			
	        }
    }


    


    public interface ICategoryService
    {
        void CreateCategory(CategoryViewModel CategoryViewModel);
        IEnumerable<CategoryViewModel> ReturnAllCategories(int storeID);
        CategoryViewModel EditCategory(int CategoryID);
        void EditCategory(CategoryViewModel CategoryViewModel);
		bool CheckDuplicate(string Categoryname, int storeid);
        void Delete(int CategoryID);
    }
}
