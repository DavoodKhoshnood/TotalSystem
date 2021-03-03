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
    public class GoodsController : Controller
    {
        private MainContext db = new MainContext();
        private IGoodsRepository goodsRepository;
        private IGoodsGroupRepository goodsGroupRepository;
        public GoodsController()
        {
            goodsRepository = new GoodsRepository(db);
            goodsGroupRepository = new GoodsGroupRepository(db);
        }

        // GET: Goods
        public ActionResult Index()
        {
            var goods = db.Goods.Include(g => g.GoodsGroup).Include(g => g.Unit);
            return View(goods.ToList());
        }

        // GET: Goods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = goodsRepository.GetGoodByID(id.Value);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(goodsGroupRepository.GetAllGoodsGroups(), "GroupID", "Title");
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title");
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodID,GroupID,Title,UnitID,ShowInSlider,ImageName,Description,CreateDate")] Good good)
        {
            if (ModelState.IsValid)
            {
                good.CreateDate = DateTime.Now;
                goodsRepository.InsertGood(good);
                goodsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(goodsGroupRepository.GetAllGoodsGroups(), "GroupID", "Title", good.GroupID);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title", good.UnitID);
            return View(good);
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = goodsRepository.GetGoodByID(id.Value);
            if (good == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(goodsGroupRepository.GetAllGoodsGroups(), "GroupID", "Title", good.GroupID);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title", good.UnitID);
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodID,GroupID,Title,UnitID,ShowInSlider,ImageName,Description,CreateDate")] Good good)
        {
            if (ModelState.IsValid)
            {
                goodsRepository.UpdateGood(good);
                goodsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(goodsGroupRepository.GetAllGoodsGroups(), "GroupID", "Title", good.GroupID);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title", good.UnitID);
            return View(good);
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = goodsRepository.GetGoodByID(id.Value);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            goodsRepository.DeleteGood(id);
            goodsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                goodsGroupRepository.Dispose();
                goodsRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
