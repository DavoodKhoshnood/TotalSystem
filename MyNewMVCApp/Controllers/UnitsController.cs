using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyNewMVCApp.Controllers
{
    public class UnitsController : Controller
    {
        private MainContext db = new MainContext();
        private IUnitRepository unitRepository;
        public UnitsController()
        {
            unitRepository = new UnitRepository(db);
        }
        // GET: Units
        public ActionResult Index()
        {
            return View(unitRepository.GetAllUnits());
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = unitRepository.GetUnitByID(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitID,Title,Countable,Symbol,UnitGroup,Coefficient,Description,CreateDate")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                unit.CreateDate = DateTime.Now;
                unit.Coefficient = 1;
                unitRepository.InsertUnit(unit);
                unitRepository.Save();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = unitRepository.GetUnitByID(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitID,Title,Countable,Symbol,UnitGroup,Coefficient,Description,CreateDate")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                unitRepository.UpdateUnit(unit);
                unitRepository.Save();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = unitRepository.GetUnitByID(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitRepository.DeleteUnit(id);
            unitRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
