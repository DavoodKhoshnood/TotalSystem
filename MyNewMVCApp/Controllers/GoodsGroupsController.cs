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
    public class GoodsGroupsController : Controller
    {
        private MainContext db = new MainContext();
        private IGoodsGroupRepository goodsGroupRepository;
        public GoodsGroupsController()
        {
            goodsGroupRepository = new GoodsGroupRepository(db);
        }

        // GET: GoodsGroups
        public ActionResult Index()
        {
            return View(goodsGroupRepository.GetAllGoodsGroups());
        }

        // GET: GoodsGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsGroup goodsGroup = goodsGroupRepository.GetGoodsGroupByID(id.Value);
            if (goodsGroup == null)
            {
                return HttpNotFound();
            }
            return View(goodsGroup);
        }

        // GET: GoodsGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoodsGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,Title,Description,CreateDate")] GoodsGroup goodsGroup)
        {
            if (ModelState.IsValid)
            {
                goodsGroupRepository.InsertGoodsGroup(goodsGroup);
                goodsGroupRepository.Save();
                return RedirectToAction("Index");
            }

            return View(goodsGroup);
        }

        // GET: GoodsGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsGroup goodsGroup = goodsGroupRepository.GetGoodsGroupByID(id.Value);
            if (goodsGroup == null)
            {
                return HttpNotFound();
            }
            return View(goodsGroup);
        }

        // POST: GoodsGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,Title,Description,CreateDate")] GoodsGroup goodsGroup)
        {
            if (ModelState.IsValid)
            {
                goodsGroupRepository.UpdateGoodsGroup(goodsGroup);
                goodsGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return View(goodsGroup);
        }

        // GET: GoodsGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsGroup goodsGroup = goodsGroupRepository.GetGoodsGroupByID(id.Value);
            if (goodsGroup == null)
            {
                return HttpNotFound();
            }
            return View(goodsGroup);
        }

        // POST: GoodsGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            goodsGroupRepository.DeleteGoodsGroup(id);
            goodsGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                goodsGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
