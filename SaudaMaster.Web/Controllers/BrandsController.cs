using System.Linq;
using System;
using System.Web.Mvc;
using SaudaMaster.SharedModel;
using SaudaMaster.Services;
using System.Web;
using System.IO;

namespace SaudaMaster.Web.Controllers
{
    public class BrandsController : Controller
    {
        private IBrandService brandServices;

        public BrandsController()
            : this(new BrandServices())
        {

        }

        public BrandsController(IBrandService brandService)
        {
            this.brandServices = brandService;
        }

        public ActionResult Index()
        {

            if (Session["StoreID"] != null)
            {
                ViewBag.Brand = new BrandViewModel();
                BrandViewModel viewModel = new BrandViewModel();
                viewModel.BrandList = brandServices.ReturnAllBrands().ToList();
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Create(BrandViewModel collection, HttpPostedFileBase file)
        {
            BrandViewModel viewModel = new BrandViewModel();

            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {

                    if (brandServices.CheckDuplicate(collection.BrandName) == false)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(("/Content/img"), fileName);
                        var SavePath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                        collection.BrandImage = path;
                        file.SaveAs(SavePath);
                        collection.BrandID = Convert.ToInt16(Session["BrandID"]);
                        brandServices.CreateBrand(collection);
                    }
                    else
                    {
                      ModelState.AddModelError("duplicate", "This brand already exist");
                        viewModel.BrandList = brandServices.ReturnAllBrands().ToList();
                        return View("Index", viewModel);
                    }
                }

                return RedirectToAction("Index");
            }


            else

            {
                viewModel.BrandList = brandServices.ReturnAllBrands().ToList();
                //viewModel.BrandImage = 
                return View("Index", viewModel);
            }

        }

        //public ActionResult Delete(int BrandID)
        //{
        //    if (Convert.ToInt32(Session["StoreID"]) != 0)
        //    {
        //        brandServices.DeleteBrand(BrandID);
        //        ViewBag.Brands = new BrandViewModel();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //}

        //public ActionResult Edit (int BrandID)
        //{
        //    if(Convert.ToInt32(Session["StoreID"]) != 0)
        //    {
        //        ViewBag.Brands = brandServices.EditBrand(BrandID);
        //        BrandViewModel viewModel = new BrandViewModel();
        //        viewModel.BrandList = brandServices.ReturnAllBrands().ToList();
        //        return RedirectToAction("Index", viewModel);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //}
    }
}