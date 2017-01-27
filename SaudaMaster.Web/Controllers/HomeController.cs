using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaudaMaster.SharedModel;
using SaudaMaster.Services;

namespace SaudaMaster.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService CustomerService;
        private ICategoryService CategoryService;
        private IItemService itemService;
        private IBrandService BrandService;
        public HomeController()
            : this(new CustomerService(),new CategoryServices(),new ItemServices(),new BrandServices())
        {

        }

        public HomeController(ICustomerService CustomerService, ICategoryService CategoryService,IItemService itemService,IBrandService BrandService)
        {
            this.CustomerService = CustomerService;
            this.CategoryService = CategoryService;
            this.itemService = itemService;
            this.BrandService = BrandService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            if (Session["StoreID"] != null)
            {
                int store = Convert.ToInt32(Session["StoreID"]);
                CustomerViewModel viewModel = new CustomerViewModel();
                CategoryViewModel viewModel1 = new CategoryViewModel();
                ItemViewModel viewModel2 = new ItemViewModel();
                BrandViewModel viewModel3 = new BrandViewModel();
                viewModel.CustomerList = CustomerService.GetAllCustomer().ToList();
                viewModel1.CategoryList = CategoryService.ReturnAllCategories(store).ToList();
                viewModel2.ItemList = itemService.ReturnAllItems(store).ToList();
                viewModel3.BrandList = BrandService.ReturnAllBrands().ToList();
                ViewBag.list = viewModel;
                ViewBag.list1 = viewModel1;
                ViewBag.list2 = viewModel2;
                ViewBag.list3 = viewModel3;
                return View(ViewBag);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

           
        }

        public ActionResult NotFound()
        {
            

            return View();
        }

        public ActionResult PageError()
        {
          

            return View();
        }
    }
}
