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
    public class StoresController : Controller
    {
        private MainContext db = new MainContext();
        private IStoreRepository storeRepository;

        public StoresController()
        {
            storeRepository = new StoreRepository(db);
        }

        // GET: Stores
        public ActionResult Index()
        {
            return View(storeRepository.GetAllStores());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreID,Title,Address,Description,CreateDate")] Store store)
        {
            if (ModelState.IsValid)
            {
                store.CreateDate = DateTime.Now;
                storeRepository.InsertStore(store);
                storeRepository.Save();
                return RedirectToAction("Index", "Stores");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = storeRepository.GetStoreByID(id.Value);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreID,Title,Address,Description,CreateDate")] Store store)
        {
            if (ModelState.IsValid)
            {
                store.CreateDate = DateTime.Now;
                storeRepository.UpdateStore(store);
                storeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = storeRepository.GetStoreByID(id.Value);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            storeRepository.DeleteStore(id);
            storeRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                storeRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
