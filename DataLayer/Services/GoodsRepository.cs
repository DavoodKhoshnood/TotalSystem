using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GoodsRepository : IGoodsRepository
    {
        private MainContext db;
        public GoodsRepository(MainContext mainContext)
        {
            this.db = mainContext;
        }
        public bool DeleteGood(Good good)
        {
            try
            {
                db.Entry(good).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGood(int id)
        {
            var good = GetGoodByID(id);
            return DeleteGood(good);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Good> GetAllGoods()
        {
            return db.Goods;
        }

        public Good GetGoodByID(int id)
        {
            return db.Goods.Find(id);
        }

        public bool InsertGood(Good good)
        {
            try
            {
                db.Goods.Add(good);
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

        public bool UpdateGood(Good good)
        {
            try
            {
                db.Entry(good).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
