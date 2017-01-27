using System.Linq;
using SaudaMaster.Services;
using SaudaMaster.SharedModel;
using System.Web.Http.Cors;
using System.Web.Mvc;
using SaudaMaster.Data;

namespace SaudaMaster.Web.Controllers.api
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]
    public class ApiController : System.Web.Http.ApiController
    {
        
        private ICategoryService CategoryServices;
        private ISubCategoryService SubCategoryServices;
        private IItemService ItemServices;
        private IStoreService StoreServices;
        private ICustomerService Customerservices;

        public ApiController()
            : this((new CategoryServices()), new SubCategoryServices(), new ItemServices(), new StoreServices(),new CustomerService())
        {

        }
        public ApiController(ICategoryService CategoryServices, ISubCategoryService SubCategoryServices, IItemService ItemServices, IStoreService StoreServices,ICustomerService Customerservices)
        {
            this.CategoryServices = CategoryServices;
            this.SubCategoryServices = SubCategoryServices;
            this.ItemServices = ItemServices;
            this.StoreServices = StoreServices;
            this.Customerservices = Customerservices;
        }
        // Returning all Stores
        [System.Web.Http.HttpGet]
        public ResponseObject Store()
        {
            ResponseObject responseObject = new ResponseObject();
            try
            {
                StoreApiModel apiModel = new StoreApiModel();
                apiModel.StoreList = StoreServices.ReturnAllStore().ToList();
                responseObject.Message = "Category";
                responseObject.Data = apiModel;
            }
            catch (System.Exception ex)
            {
                responseObject.Message = "400";
                responseObject.Message = ex.Message;

            }
            return responseObject;
        }
        // Returning all categories w.r.t Store
        [System.Web.Http.HttpGet]
        public ResponseObject Category(int id)
        {
            ResponseObject responseObject = new ResponseObject();
            try
            {
                CategoryApiModel apiModel = new CategoryApiModel();
                apiModel.CategoryList = CategoryServices.ReturnAllCategories(id).ToList();
                responseObject.Message = "Category";
                responseObject.Data = apiModel;
            }
            catch (System.Exception ex)
            {
                responseObject.Message = "400";
                responseObject.Message = ex.Message;

            }
            return responseObject;
        }
        // Returning all subcategories w.r.t Category
        [System.Web.Http.HttpGet]
        public ResponseObject SubCategory(int id)
        {
            ResponseObject responseObject = new ResponseObject();
            try
            {
                SubCategoryApiModel apiModel = new SubCategoryApiModel();
                apiModel.SubCategoryList = SubCategoryServices.ReturnAllSubCategoriesw(id).ToList();
                responseObject.Message = "List of SubCategories";
                responseObject.Data = apiModel;
            }
            catch (System.Exception ex)
            {
                responseObject.Message = "400";
                responseObject.Message = ex.Message;

            }
            return responseObject;
        }
        // Returning all items w.r.t SubCategory
        [System.Web.Http.HttpGet]
        public ResponseObject Item(int id)
        {
            ResponseObject responseObject = new ResponseObject();
            try
            {
                ItemApiModel  apiModel = new ItemApiModel();
                apiModel.ItemList = ItemServices.ReturnAllItemswrtsc(id).ToList();
                responseObject.Message = "List of Items";
                responseObject.Data = apiModel;
            }
            catch (System.Exception ex)
            {
                responseObject.Message = "400";
                responseObject.Message = ex.Message;

            }
            return responseObject;
        }
        [System.Web.Http.HttpPost]
        public int RegisterCustomer(CustomerViewModel customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            var CustomerID = StoreServices.RegisterCustomer(customer);
            return CustomerID;
        }
    }
}