using System;
using SaudaMaster.Data;
using SaudaMaster.Infrastructure.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudaMaster.Infrastructure.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IDatabaseFactory databaseFactory)
            :base (databaseFactory)
        {

        }
    }
    public interface IItemRepository : IRepository<Item>
    {

    }
}
