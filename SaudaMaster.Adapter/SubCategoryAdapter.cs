using System.Collections.Generic;
using System.Linq;
using SaudaMaster.Infrastructure.Common;
using SaudaMaster.Infrastructure.Repository;
using SaudaMaster.SharedModel;
using SaudaMaster.Data; 

namespace SaudaMaster.Adapter
{
    public class SubCategoryAdapter
    {

        private ISubCategoryRepository SubCategoryRepository;
        private IUnityOfWork UnityOfWork;
        ItemAdapter del = new ItemAdapter();
        

        public SubCategoryAdapter()
        {
            UnityOfWork = new UnityOfWork(new DatabaseFactory());
            SubCategoryRepository = new SubCategoryRepository(UnityOfWork.instance);
        }

        public void CreateSubCategory(SubCategoryViewModel collection)
        {

            SubCategory subcategory = new SubCategory()
            {
                SubCategoryID = collection.SubCategoryID,
                CategoryID = collection.CategoryID   , /*SubCategoryViewModel.CategoryID,*/
                SubCategoryDisplayName = collection.SubCategoryDisplayName,
                SubCategoryName = collection.SubCategoryName,
                SubCategoryImage = collection.SubCategoryImage,
            };
            SubCategoryRepository.Add(subcategory);
            UnityOfWork.Commit();
        }      
        
        public IEnumerable<SubCategoryViewModel> ReturnAllSubCategory(int store)
        {
            var subcategory = SubCategoryRepository.GetAll();
            var subcategoryref = from s in subcategory where s.Category.StoreID == store select s;
            List<SubCategoryViewModel> result = new List<SubCategoryViewModel>();
            foreach (var item in subcategoryref)
            {
                result.Add(new SubCategoryViewModel
                {
                    SubCategoryID = item.SubCategoryID,
                    SubCategoryName = item.SubCategoryName,
                    CategoryID = item.CategoryID,
                    SubCategoryDisplayName = item.SubCategoryDisplayName,
                    SubCategoryImage = item.SubCategoryImage,
                    CategoryName = item.Category.CategoryName

                });
            }
            return result;
        }
        public IEnumerable<SubCategoryViewModel> ReturnAllSubCategoryw(int categoryID)
        {
            var subcategory = SubCategoryRepository.GetAll();
            var subcategoryref = from s in subcategory where s.Category.CategoryID == categoryID select s;
            List<SubCategoryViewModel> result = new List<SubCategoryViewModel>();
            foreach (var item in subcategoryref)
            {
                result.Add(new SubCategoryViewModel
                {
                    SubCategoryID = item.SubCategoryID,
                    SubCategoryName = item.SubCategoryName,
                    CategoryID = item.CategoryID,
                    SubCategoryDisplayName = item.SubCategoryDisplayName,
                    SubCategoryImage = item.SubCategoryImage,
                    CategoryName = item.Category.CategoryName

                });
            }
            return result;
        }

        public SubCategoryViewModel EditSubCategory(int SubCategoryID)
        {
            var getSubcategory = SubCategoryRepository.GetById(SubCategoryID);
            SubCategoryViewModel subcategory = new SubCategoryViewModel();
            subcategory.SubCategoryID = getSubcategory.SubCategoryID;
            subcategory.SubCategoryName = getSubcategory.SubCategoryName;
            subcategory.SubCategoryDisplayName = getSubcategory.SubCategoryDisplayName;
            subcategory.SubCategoryImage = getSubcategory.SubCategoryImage;
            subcategory.CategoryID = getSubcategory.CategoryID;
            subcategory.CategoryName = getSubcategory.Category.CategoryName;
            return subcategory;
        }

        public void EditSubCategory(SubCategoryViewModel SubCategoryViewModel)
        {
            SubCategory subcategory = new SubCategory();
            subcategory.SubCategoryID = SubCategoryViewModel.SubCategoryID;
            subcategory.SubCategoryName = SubCategoryViewModel.SubCategoryName;
            subcategory.SubCategoryDisplayName = SubCategoryViewModel.SubCategoryDisplayName;
            subcategory.SubCategoryImage = SubCategoryViewModel.SubCategoryImage;
            subcategory.CategoryID = SubCategoryViewModel.CategoryID;
            SubCategoryRepository.Update(subcategory);
            UnityOfWork.Commit();

        }

        public void DeleteSubCategory(int SubCategoryID)
        {
            del.DeleteAllItems(SubCategoryID);
            SubCategoryRepository.Delete(SubCategoryRepository.GetById(SubCategoryID));
            UnityOfWork.Commit();
        }

        public void DeleteAllSubCategories(int categoryID)
        {
            var sbcat = SubCategoryRepository.GetAll().Where(x => x.CategoryID == categoryID);
            if (sbcat != null)
            {
                foreach (var subcategory in sbcat)
                {
                    del.DeleteAllItems(subcategory.SubCategoryID);
                    SubCategoryRepository.Delete(subcategory);
                }
            }
            UnityOfWork.Commit();
        }




    }
}