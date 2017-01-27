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
    public class StoreAdapter
    {
        private IStoreRepository StoreRepository;
        private IUnityOfWork UnityOfWork;

        public StoreAdapter()
        {
            UnityOfWork = new UnityOfWork(new DatabaseFactory());
            StoreRepository = new StoreRepository(UnityOfWork.instance);
        }

        public IEnumerable<StoreViewModel> ReturnAllStore()
        {
            var store = StoreRepository.GetAll();
            List<StoreViewModel> result = new List<StoreViewModel>();
            foreach(var item in store)
            {
                result.Add(new StoreViewModel
                {
                    StoreID = item.StoreID,
                    StoreName = item.StoreName,
                    StoreLogo = item.StoreLogo
                });
            }
            return result;
        }
    }
}
