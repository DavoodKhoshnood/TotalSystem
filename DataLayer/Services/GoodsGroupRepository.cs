using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GoodsGroupRepository : IGoodsGroupRepository
    {
        private MainContext db;
        public GoodsGroupRepository(MainContext mainContext)
        {
            this.db = mainContext;
        }
        public bool DeleteGoodsGroup(GoodsGroup goodsGroup)
        {
            try
            {
                db.Entry(goodsGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGoodsGroup(int id)
        {
            var goodgroup = GetGoodsGroupByID(id);
            return DeleteGoodsGroup(goodgroup);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<GoodsGroup> GetAllGoodsGroups()
        {
            return db.GoodsGroups;
        }

        public GoodsGroup GetGoodsGroupByID(int id)
        {
            return db.GoodsGroups.Find(id);
        }

        public bool InsertGoodsGroup(GoodsGroup goodsGroup)
        {
            try
            {
                db.GoodsGroups.Add(goodsGroup);
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

        public bool UpdateGoodsGroup(GoodsGroup goodsGroup)
        {
            try
            {
                db.Entry(goodsGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
