using System.Collections.Generic;
using System.Linq;
using SaudaMaster.Infrastructure.Common;
using SaudaMaster.Infrastructure.Repository;
using SaudaMaster.SharedModel;
using SaudaMaster.Data;

namespace SaudaMaster.Adapter
{
    public class CategoryAdapter
    {
        private ICategoryRepository CategoryRepository;
        private IUnityOfWork UnityOfWork;
        SubCategoryAdapter del = new SubCategoryAdapter();

        public CategoryAdapter()
        {
            UnityOfWork = new UnityOfWork(new DatabaseFactory());
            CategoryRepository = new CategoryRepository(UnityOfWork.instance);
        }

        public void CreateCategory(CategoryViewModel CategoryViewModel)
        {
            Category Category = new Category()
            {
                CategoryID = CategoryViewModel.CategoryID,
                StoreID = CategoryViewModel.StoreID,
                CategoryName = CategoryViewModel.CategoryName,
                CategoryDisplayName = CategoryViewModel.CategoryDisplayName,
                CategoryImage = CategoryViewModel.CategoryImage
            };
            CategoryRepository.Add(Category);
            UnityOfWork.Commit();
        }

        public IEnumerable<CategoryViewModel> ReturnAllCategories(int store)
        {
            var getcategory = CategoryRepository.GetAll().Where(x => x.StoreID == store).ToList();
            List<CategoryViewModel> result = new List<CategoryViewModel>();

            foreach (var item in getcategory)
            {
                result.Add(new CategoryViewModel {

                    CategoryID = item.CategoryID,
                    CategoryName = item.CategoryName,
                    CategoryDisplayName = item.CategoryDisplayName,
                    CategoryImage = item.CategoryImage
                });
            } 
            return result ;
        }

        public CategoryViewModel EditCategory(int CategoryID)
        {
            var getcategory = CategoryRepository.GetById(CategoryID);
            CategoryViewModel  category = new CategoryViewModel();
            category.CategoryID = getcategory.CategoryID;
            category.StoreID = getcategory.StoreID;
            category.CategoryName = getcategory.CategoryName;
            category.CategoryDisplayName = getcategory.CategoryDisplayName;
            category.CategoryImage = getcategory.CategoryImage;
            return category;
        }

        public void EditCategory(CategoryViewModel CategoryViewModel)
        {
                Category  category = new Category();
                category.CategoryID = CategoryViewModel.CategoryID;
                category.StoreID = CategoryViewModel.StoreID;
                category.CategoryName = CategoryViewModel.CategoryName;
                category.CategoryDisplayName = CategoryViewModel.CategoryDisplayName;
                category.CategoryImage = CategoryViewModel.CategoryImage;
                CategoryRepository.Update(category);
                UnityOfWork.Commit();
        }

        public void DeleteCategory(int CategoryID)
        {
            del.DeleteAllSubCategories(CategoryID);
            CategoryRepository.Delete(CategoryRepository.GetById(CategoryID));
            UnityOfWork.Commit();
        }
    }
}
