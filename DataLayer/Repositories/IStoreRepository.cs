using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IStoreRepository : IDisposable
    {
        IEnumerable<Store> GetAllStores();
        Store GetStoreByID(int id);
        bool InsertStore(Store store);
        bool UpdateStore(Store store);
        bool DeleteStore(Store store);
        bool DeleteStore(int id);

        void Save();
    }
}
