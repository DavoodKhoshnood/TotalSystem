using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StoreRepository : IStoreRepository
    {
        private MainContext db;
        public StoreRepository(MainContext mainContext)
        {
            this.db = mainContext;
        }
        public bool DeleteStore(Store store)
        {
            try
            {
                db.Entry(store).State = EntityState.Deleted;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteStore(int id)
        {
            var store = GetStoreByID(id);
            return DeleteStore(store);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Store> GetAllStores()
        {
            return db.Stores;
        }

        public Store GetStoreByID(int id)
        {
            return db.Stores.Find(id);
        }

        public bool InsertStore(Store store)
        {
            try
            {
                db.Stores.Add(store);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool UpdateStore(Store store)
        {
            try
            {
                db.Entry(store).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
