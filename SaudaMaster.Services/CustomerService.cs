using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Adapter;
using SaudaMaster.SharedModel;
using SaudaMaster.Services;

namespace SaudaMaster.Services
{
     public class CustomerService : ICustomerService
    {
        CustomerAdapter customerAdapter;

        public CustomerService()
        {
            this.customerAdapter = new CustomerAdapter();
        }

        public void RegisterCustomer(CustomerViewModel customerViewModel)
        {
            customerAdapter.RegisterCustomer(customerViewModel);
        }
        public IEnumerable<CustomerViewModel> GetAllCustomer()
        {
            return customerAdapter.GetAllCustomer();
        }
    }

    public interface ICustomerService
    {
        void RegisterCustomer(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAllCustomer();
    }
}
