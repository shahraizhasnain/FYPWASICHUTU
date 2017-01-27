using System.Linq;
using System;
using System.Web.Mvc;
using SaudaMaster.SharedModel;
using SaudaMaster.Services;
using System.Web;
using System.IO;
using SaudaMaster.Data;

namespace SaudaMaster.Web.Controllers
{
    public class ItemController : Controller
    {
        private IItemService ItemServices;

        public ItemController()
            : this(new ItemServices())
        {

        }

        public ItemController(IItemService ItemService)
        {
            this.ItemServices = ItemService;
        }

        public ActionResult Index()
        {
            if (Session["StoreID"] != null)
            {
                int store = Convert.ToInt32(Session["StoreID"]);
                ItemViewModel viewModel = new ItemViewModel();
                CommonViewModel all = new CommonViewModel();
                viewModel.ItemList = ItemServices.ReturnAllItems(store).ToList();
                all.CategoryList = ItemServices.ReturnAllCategories(store).ToList();
                all.SubCategoryList = ItemServices.ReturnAllSubCategories(store).ToList();
                all.BrandList = ItemServices.ReturnAllBrands().ToList();
                ViewBag.cat = all.CategoryList;
                ViewBag.sub = all.SubCategoryList;
                ViewBag.brand = all.BrandList;

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index","Login");
            }

        }

        [HttpPost]
        public ActionResult Create(ItemViewModel collection, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(("/Content/img"), fileName);
                    var SavePath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                    collection.ItemImage = path;
                    file.SaveAs(SavePath);
                    collection.StoreID = Convert.ToInt32(Session["StoreID"]);
                    collection.ItemID = Convert.ToInt16(Session["ItemID"]);
                    ItemServices.CreateItem(collection);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int itemID)
        {
            ItemServices.DeleteItem(itemID);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ItemID)
        {
            int store = Convert.ToInt32(Session["StoreID"]);
            ViewBag.data = ItemServices.EditItem(ItemID);
            CommonViewModel all = new CommonViewModel();
            ItemViewModel item = new ItemViewModel();
            all.CategoryList = ItemServices.ReturnAllCategories(store).ToList();
            all.SubCategoryList = ItemServices.ReturnAllSubCategories(store).ToList();
            all.BrandList = ItemServices.ReturnAllBrands().ToList();
            ViewBag.cat = all.CategoryList;
            ViewBag.sub = all.SubCategoryList;
            ViewBag.brand = all.BrandList;
            item.ItemList = ItemServices.ReturnAllItems(store).ToList();

            return View("Index", item);
        }
    }
}