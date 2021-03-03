using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitRepository : IUnitRepository
    {
        private MainContext db;
        public UnitRepository(MainContext mainContext)
        {
            this.db = mainContext;
        }
        public bool DeleteUnit(Unit unit)
        {
            try
            {
                db.Entry(unit).State = EntityState.Deleted;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteUnit(int id)
        {
            var unit = GetUnitByID(id);
            return DeleteUnit(unit);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return db.Units;
        }

        public Unit GetUnitByID(int id)
        {
            return db.Units.Find(id);
        }

        public bool InsertUnit(Unit unit)
        {
            try
            {
                db.Units.Add(unit);
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

        public bool UpdateUnit(Unit unit)
        {
            try
            {
                db.Entry(unit).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
