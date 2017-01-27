using System;
using System.Collections.Generic;
using System.Linq;
using SaudaMaster.Infrastructure.Common;
using SaudaMaster.Infrastructure.Repository;
using SaudaMaster.SharedModel;
using SaudaMaster.Data;

namespace SaudaMaster.Adapter
{
    public class ItemAdapter
    {
        private IItemRepository ItemRepository;
        private IUnityOfWork UnityOfWork;

        public ItemAdapter()
        {
            UnityOfWork = new UnityOfWork(new DatabaseFactory());
            ItemRepository = new ItemRepository(UnityOfWork.instance);
        }

        public void CreateItem(ItemViewModel ItemViewModel)
        {
            Item Item = new Item()
            {
                ItemID = ItemViewModel.ItemID,
                BrandID = ItemViewModel.BrandID,
                CategoryID = ItemViewModel.CategoryID,
                SubCategoryID = ItemViewModel.SubCategoryID,
                StoreID = ItemViewModel.StoreID,
                ItemName = ItemViewModel.ItemName,
                ItemDescription = ItemViewModel.ItemDescription,
                ItemPrice = ItemViewModel.ItemPrice,
                ItemAvailability = Convert.ToBoolean(ItemViewModel.ItemAvailability),
                ItemDiscountPercentage = ItemViewModel.ItemDiscountPercentage,
                ItemImage = ItemViewModel.ItemImage
            };
            ItemRepository.Add(Item);
            UnityOfWork.Commit();
        }

        public IEnumerable<ItemViewModel> ReturnAllItems(int store)
        {
            var Items = ItemRepository.GetAll().Where(x => x.StoreID == store).ToList();
            List<ItemViewModel> result = new List<ItemViewModel>();
            foreach (var item in Items)
            {
                result.Add(new ItemViewModel
                {
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    ItemDescription = item.ItemDescription,
                    ItemPrice = item.ItemPrice,
                    ItemAvailability = item.ItemAvailability.ToString(),
                    ItemDiscountPercentage = Convert.ToDecimal(item.ItemDiscountPercentage),
                    ItemImage = item.ItemImage,
                });
            }
            return result;
        }
        public IEnumerable<ItemViewModel> ReturnAllItemswrtsc(int SubcategoryID)
        {

            var items = ItemRepository.GetAll();
            var itemref = from s in items where s.SubCategory.SubCategoryID == SubcategoryID select s;

         //   var Items = ItemRepository.GetAll().Where(x => x.SubCategoryID == SubcategoryID).ToList();
            List<ItemViewModel> result = new List<ItemViewModel>();
            foreach (var item in itemref)
            {
                result.Add(new ItemViewModel
                {
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    ItemDescription = item.ItemDescription,
                    ItemPrice = item.ItemPrice,
                    ItemAvailability = item.ItemAvailability.ToString(),
                    ItemDiscountPercentage = Convert.ToDecimal(item.ItemDiscountPercentage),
                    ItemImage = item.ItemImage,
                    StoreID = item.StoreID
                });
            }
            return result;
        }
        public ItemViewModel EditItem(int ItemID)
        {
            var getitem = ItemRepository.GetById(ItemID);
            ItemViewModel item = new ItemViewModel();
            item.ItemID = getitem.ItemID;
            item.CategoryID = getitem.CategoryID;
            item.SubCategoryID = getitem.SubCategoryID;
            item.BrandID = getitem.BrandID;
			item.StoreID = getitem.StoreID;
            item.ItemName = getitem.ItemName;
            item.ItemDescription = getitem.ItemDescription;
            item.ItemPrice = getitem.ItemPrice;
            item.ItemAvailability = Convert.ToString(getitem.ItemAvailability);
            item.ItemDiscountPercentage = Convert.ToDecimal(getitem.ItemDiscountPercentage);
            item.ItemImage = getitem.ItemImage;
            return item;
        }

        public void EditItem(ItemViewModel itemViewModel)
        {
            Item item = new Item();
            item.ItemID = itemViewModel.ItemID;
            item.CategoryID = itemViewModel.CategoryID;
            item.SubCategoryID = itemViewModel.SubCategoryID;
            item.BrandID = itemViewModel.BrandID;
			item.StoreID = itemViewModel.StoreID;
            item.ItemName = itemViewModel.ItemName;
            item.ItemDescription = itemViewModel.ItemDescription;
            item.ItemPrice = itemViewModel.ItemPrice;
            item.ItemAvailability = Convert.ToBoolean(itemViewModel.ItemAvailability);
            item.ItemDiscountPercentage = itemViewModel.ItemDiscountPercentage;
            item.ItemImage = itemViewModel.ItemImage;
            ItemRepository.Update(item);
            UnityOfWork.Commit();
        }
		
		public bool CheckDuplicate(string itemname,int subategoryid)			
	        {			
	            //w.r.t to storeid			
	            //var item = ItemRepository.GetAll().Where(x => x.Category.StoreID == storeid).ToList();			
	            //w.r.t to subcategoryid			
	            var item = ItemRepository.GetAll().Where(x => x.SubCategoryID == subategoryid).ToList();			
				
	            var exist = from i in item where i.ItemName == itemname select i;			
				
	            if(exist.Count()>0)			
	            {			
	                return true;			
	            }			
	            else			
	            {			
	                return false;			
	            }			
      }

        public void DeleteItem(int itemID)
        {
            ItemRepository.Delete(ItemRepository.GetById(itemID));
            UnityOfWork.Commit();
        }

        public void DeleteAllItems(int subcategoryID)
        {
            var item = ItemRepository.GetAll().Where(x => x.SubCategoryID == subcategoryID);
            if (item != null)
            {
                foreach (var items in item)
                {
                    ItemRepository.Delete(items);
                }
            }
            UnityOfWork.Commit();
        }

        public void GetDiscount(DiscountViewModel itemViewModel)
        {

            Item item = ItemRepository.GetById(itemViewModel.ItemID);
            //item.ItemID = itemViewModel.ItemID;

            item.ItemDiscountPercentage = itemViewModel.ItemDiscountPercentage;
            ItemRepository.Update(item);
            UnityOfWork.Commit();
        }
        public void GetPromotion(PromotionViewModel ViewModel)
        {

            Item item = ItemRepository.GetById(ViewModel.ItemID);

            item.Promotion = ViewModel.Promotion;
            ItemRepository.Update(item);
            UnityOfWork.Commit();
        }

    }
}

