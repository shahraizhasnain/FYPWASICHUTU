using SaudaMaster.Data;
using SaudaMaster.Infrastructure.Common;

namespace SaudaMaster.Infrastructure.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {


        public CustomerRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {

    }
}
