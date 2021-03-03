using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUnitRepository : IDisposable
    {
        IEnumerable<Unit> GetAllUnits();
        Unit GetUnitByID(int id);

        bool InsertUnit(Unit unit);
        bool UpdateUnit(Unit unit);
        bool DeleteUnit(Unit unit);
        bool DeleteUnit(int id);

        void Save();
    }
}
