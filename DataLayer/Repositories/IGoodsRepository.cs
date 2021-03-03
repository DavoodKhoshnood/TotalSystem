using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IGoodsRepository : IDisposable
    {
        IEnumerable<Good> GetAllGoods();
        Good GetGoodByID(int id);

        bool InsertGood(Good good);
        bool UpdateGood(Good good);
        bool DeleteGood(Good good);
        bool DeleteGood(int id);

        void Save();
    }
}
