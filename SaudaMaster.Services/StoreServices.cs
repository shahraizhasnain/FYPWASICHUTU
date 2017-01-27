using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Adapter;
using SaudaMaster.SharedModel;
using SaudaMaster.Data;

namespace SaudaMaster.Services
{
    public class StoreServices : IStoreService
    {
        CustomerAdapter customerAdapter;
        StoreAdapter storeAdapter;
        public StoreServices()
        {
            this.storeAdapter = new StoreAdapter();
            this.customerAdapter = new CustomerAdapter();
        }

        public int RegisterCustomer(CustomerViewModel customerViewModel)
        {
           return customerAdapter.RegisterCustomer(customerViewModel);
        }

        public IEnumerable<StoreViewModel> ReturnAllStore()
        {
            return storeAdapter.ReturnAllStore();
        }
    }
    public interface IStoreService
    {
        IEnumerable<StoreViewModel> ReturnAllStore();
        int RegisterCustomer(CustomerViewModel customerViewModel);
    }
}
