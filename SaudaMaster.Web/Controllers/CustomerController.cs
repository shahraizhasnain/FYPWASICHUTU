using System.Linq;
using System;
using System.Web.Mvc;
using SaudaMaster.SharedModel;
using SaudaMaster.Services;
using System.Web;
using System.IO;

namespace SaudaMaster.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService CustomerService;


        public CustomerController()
            : this(new CustomerService())
        {

        }

        public CustomerController(ICustomerService CustomerService)
        {
            this.CustomerService = CustomerService;
        }

        public ActionResult Index()
        {
            return View();
            
        }
    }
}