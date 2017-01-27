using SaudaMaster.Services;
using SaudaMaster.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaudaMaster.Web.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService loginService;
        public LoginController()
            :this (new LoginService())
        {

        }

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        // GET: Login
        public ActionResult Index()
        {
            Session["LoginSession"] = null;
            Session["StoreID"] = null;
            Session["StoreUserName"] = null;
            Session["StoreName"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                LoginViewModel viewModel = loginService.Authenticate(loginViewModel);
                if (viewModel.StoreID == 0)
                {
                    return View();
                }
                else
                {

                    Session["LoginSession"] = viewModel;
                    Session["StoreID"] = viewModel.StoreID;
                    Session["StoreUserName"] = viewModel.StoreUsername;
                    Session["StoreName"] = viewModel.StoreName;
                    return RedirectToAction("Index", "Home/Index");
                }
            }
            else
            {
                return View();
            }

        }
    }
}