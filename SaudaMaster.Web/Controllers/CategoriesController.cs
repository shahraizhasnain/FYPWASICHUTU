using System.Linq;
using System;
using System.Web.Mvc;
using SaudaMaster.SharedModel;
using SaudaMaster.Services;
using System.Web;
using System.IO;

namespace SaudaMaster.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService CategoryServices;


        public CategoriesController()
            : this(new CategoryServices())
        {

        }

        public CategoriesController(ICategoryService CategoryServices)
        {
            this.CategoryServices = CategoryServices;
        }

        public ActionResult Index()
        {
            if (Session["StoreID"] != null)
            {
                int store = Convert.ToInt32(Session["StoreID"]);
                CategoryViewModel viewModel = new CategoryViewModel();
                viewModel.CategoryList = CategoryServices.ReturnAllCategories(store).ToList();

                return View(viewModel);
            } else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel collection, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if(collection.CategoryID == 0)
                { 
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(("/Content/img"), fileName);
                    var SavePath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                    collection.CategoryImage = path;
                    file.SaveAs(SavePath);
                    collection.CategoryID = Convert.ToInt16(Session["CategoryID"]);
                    collection.StoreID = Convert.ToInt32(Session["StoreID"]);
                    CategoryServices.CreateCategory(collection);
                    }
                    
                }
                else
                {
                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(("/Content/img"), fileName);
                        var SavePath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                        collection.CategoryImage = path;
                        file.SaveAs(SavePath);

                    }

                    CategoryServices.EditCategory(collection);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CategoryID)
        {
            CategoryServices.Delete(CategoryID);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int CategoryID)
        {
            int store = Convert.ToInt32(Session["StoreID"]);
            ViewBag.Categories = CategoryServices.EditCategory(CategoryID);
            CategoryViewModel category = new CategoryViewModel();
            category.CategoryList = CategoryServices.ReturnAllCategories(store).ToList();
            return View("Index", category);
        }
    }
}