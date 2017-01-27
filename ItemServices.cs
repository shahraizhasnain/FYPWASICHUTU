using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Adapter;
using SaudaMaster.SharedModel;

namespace SaudaMaster.Services
{
    public class ItemServices : IItemService
    {
        SubCategoryAdapter subcategoryAdapter;
        CategoryAdapter categoryAdapter;
        BrandAdapter brandAdapter;
        ItemAdapter ItemAdapter;
     public ItemServices()
        {
            this.ItemAdapter = new ItemAdapter();
            this.subcategoryAdapter = new SubCategoryAdapter();
            this.categoryAdapter = new CategoryAdapter();
            this.brandAdapter = new BrandAdapter();
        }

        public IEnumerable<ItemViewModel> ReturnAllItems(int store)
        {
            return ItemAdapter.ReturnAllItems(store);
        }
        public IEnumerable<ItemViewModel> ReturnAllItemswrtsc(int SubcategoryID)
        {
            return ItemAdapter.ReturnAllItemswrtsc(SubcategoryID);
        }

        public void CreateItem(ItemViewModel ItemViewModel)
        {
            ItemAdapter.CreateItem(ItemViewModel);
        }

        public ItemViewModel EditItem(int ItemID)
        {
            return ItemAdapter.EditItem(ItemID);
        }

        public void EditItem (ItemViewModel itemViewModel)
        {
            ItemAdapter.EditItem(itemViewModel);
        }

        public void DeleteItem(int itemID)
        {
            ItemAdapter.DeleteItem(itemID);
        }

        public IEnumerable<CategoryViewModel> ReturnAllCategories(int store)
        {
            return categoryAdapter.ReturnAllCategories(store);
        }

        public IEnumerable<SubCategoryViewModel> ReturnAllSubCategories(int store)
        {
            return subcategoryAdapter.ReturnAllSubCategory(store);
        }

        public IEnumerable<BrandViewModel> ReturnAllBrands()
        {
            return brandAdapter.ReturnAllBrands();
        }
    }
    public interface IItemService
    {
        void CreateItem(ItemViewModel ItemViewModel);
        IEnumerable<ItemViewModel> ReturnAllItems(int store);
        IEnumerable<ItemViewModel> ReturnAllItemswrtsc(int SubcategoryID);
        IEnumerable<SubCategoryViewModel> ReturnAllSubCategories(int store);
        IEnumerable<CategoryViewModel> ReturnAllCategories(int store);
        IEnumerable<BrandViewModel> ReturnAllBrands();
        ItemViewModel EditItem(int ItemID);
        void EditItem(ItemViewModel itemViewModel);
        void DeleteItem(int itemID);
        //bool CheckDuplicate(BrandViewModel brand);
        //bool CheckDuplicateForUpdate(string brand, int id);
    }
}
