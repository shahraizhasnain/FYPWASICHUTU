using System.Linq;
using System;
using System.Web.Mvc;
using SaudaMaster.SharedModel;
using SaudaMaster.Services;
using System.Web;
using System.IO;
using SaudaMaster.Data;
using SaudaMaster.Adapter;

namespace SaudaMaster.Web.Controllers
{
    public class SubCategoryController : Controller
    {
        //private ICategoryService categoryservices;
        private ISubCategoryService subcategoryservices;


        public SubCategoryController()
            : this(new SubCategoryServices())
        {

        }

        public SubCategoryController(ISubCategoryService subcategoryservice)
        {
            this.subcategoryservices = subcategoryservice;
        }

        public ActionResult Index()
        {

            if (Session["StoreID"] != null)
            {
                int store = Convert.ToInt32(Session["StoreID"]);
                SubCategoryViewModel viewModel = new SubCategoryViewModel();
                CategoryViewModel category = new CategoryViewModel();
                category.CategoryList = subcategoryservices.ReturnAllCategories(store).ToList();
                ViewBag.cat = category.CategoryList;
                viewModel.SubCategoryList = subcategoryservices.ReturnAllSubCategory(store).ToList();
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Create(SubCategoryViewModel collection, HttpPostedFileBase file)
        {
            int store = Convert.ToInt32(Session["StoreID"]);
            SubCategoryViewModel viewModel = new SubCategoryViewModel();
            CategoryViewModel category = new CategoryViewModel();

            if (ModelState.IsValid)
            {
                if (collection.SubCategoryID == 0)
                {
                   
                    if (file != null)
                    {
                        // if (subcategoryservices.CheckDuplicate(collection.SubCategoryName, store)==false)
                        if (subcategoryservices.CheckDuplicate(collection.SubCategoryName, collection.CategoryID) == false)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(("/Content/img"), fileName);
                            var SavePath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                            collection.SubCategoryImage = path;
                            file.SaveAs(SavePath);
                            subcategoryservices.CreateSubCategory(collection);
                        }
                        else
                        {
                            ModelState.AddModelError("duplicate", "This SubCategory already exist");
                            category.CategoryList = subcategoryservices.ReturnAllCategories(store).ToList();
                            ViewBag.cat = category.CategoryList;
                            viewModel.SubCategoryList = subcategoryservices.ReturnAllSubCategory(store).ToList();
                            return View("Index", viewModel);
                        }
                    }
                }
                else
                {
                   
                     
                        if (file != null)
                        {

                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(("/Content/img"), fileName);
                            var SavePath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                            collection.SubCategoryImage = path;
                            file.SaveAs(SavePath);
                            subcategoryservices.EditSubCategory(collection);
                        }
                        else
                        {
                            subcategoryservices.EditSubCategory(collection);
                        }

                    
                }
                return RedirectToAction("Index");
            }
            else
            {
                category.CategoryList = subcategoryservices.ReturnAllCategories(store).ToList();
                ViewBag.cat = category.CategoryList;
                viewModel.SubCategoryList = subcategoryservices.ReturnAllSubCategory(store).ToList();
                return View("Index", viewModel);
            }

        }

        public ActionResult Edit(int SubCategoryID)
        {
            int store = Convert.ToInt32(Session["StoreID"]);
            //SubCategoryViewModel data = new SubCategoryViewModel();
            ViewBag.data = subcategoryservices.EditSubCategory(SubCategoryID);
            ViewBag.cat = subcategoryservices.ReturnAllCategories(store);
            SubCategoryViewModel subcategory = new SubCategoryViewModel();
            subcategory.SubCategoryList = subcategoryservices.ReturnAllSubCategory(store).ToList();
            return View("Index", subcategory);
        }

        public ActionResult Delete(int SubCategoryID)
        {
            subcategoryservices.DeleteSubCategory(SubCategoryID);
            return RedirectToAction("Index");
        }
    }
}