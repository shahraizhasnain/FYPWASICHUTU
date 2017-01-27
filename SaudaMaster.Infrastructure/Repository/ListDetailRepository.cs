using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudaMaster.Data;
using SaudaMaster.Infrastructure.Common;

namespace SaudaMaster.Infrastructure.Repository
{
    public class ListDetailRepository : RepositoryBase<ListDetail> , IListDetailRepository
    {
        public ListDetailRepository(IDatabaseFactory databaseFactory)
            :base (databaseFactory)
        {

        }
    }

    public interface IListDetailRepository : IRepository<ListDetail>
    {

    }
}
