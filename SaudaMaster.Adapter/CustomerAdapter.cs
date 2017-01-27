using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Infrastructure.Common;
using SaudaMaster.Infrastructure.Repository;
using SaudaMaster.SharedModel;
using SaudaMaster.Data;

namespace SaudaMaster.Adapter
{
    public class CustomerAdapter
    {
        private IUnityOfWork unityOfWork;
        private ICustomerRepository CustomerRepository;

        public CustomerAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            CustomerRepository = new CustomerRepository(unityOfWork.instance);
        }

        public int RegisterCustomer(CustomerViewModel customerViewModel)
        {
            Customer customer = new Customer()
            {
                CustomerName = customerViewModel.CustomerName,
                CustomerAddress1 = customerViewModel.CustomerAddress1,
                CustomerContact = customerViewModel.CustomerContact,
               
            };
            
            var customerExsist = (from Customer in unityOfWork.db.Customers where Customer.CustomerContact == customer.CustomerContact select Customer.CustomerID).FirstOrDefault();
            if(customerExsist == 0)
            {
                CustomerRepository.Add(customer);
                unityOfWork.Commit();
                var customerID = (from Customer in unityOfWork.db.Customers where Customer.CustomerContact == customer.CustomerContact select Customer.CustomerID).FirstOrDefault();
                return (customerID);
            }
            else
            {
                return customerExsist;
            }
        
        } 
        public IEnumerable<CustomerViewModel> GetAllCustomer()
        {
            var Customers = CustomerRepository.GetAll();
            List<CustomerViewModel> Customerviewmodel = new List<CustomerViewModel>();

            foreach(var customer in Customers)
            {
                Customerviewmodel.Add(new CustomerViewModel
                {
                    CustomerName = customer.CustomerName,
                    CustomerContact = customer.CustomerContact,
                    CustomerAddress1=customer.CustomerAddress1
                
                });
            }
            return Customerviewmodel;

        }
    }
}
