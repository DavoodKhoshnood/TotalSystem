using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IGoodsGroupRepository : IDisposable
    {
        IEnumerable<GoodsGroup> GetAllGoodsGroups();
        GoodsGroup GetGoodsGroupByID(int id);

        bool InsertGoodsGroup(GoodsGroup goodsGroup);
        bool UpdateGoodsGroup(GoodsGroup goodsGroup);
        bool DeleteGoodsGroup(GoodsGroup goodsGroup);
        bool DeleteGoodsGroup(int id);

        void Save();
    }
}
