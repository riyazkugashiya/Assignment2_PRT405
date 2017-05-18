using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using updatetabledemo;

namespace updatetabledemo.Controllers
{
    public class tblItemDetailsController : Controller
    {
        private testtabledemoEntities db = new testtabledemoEntities();

        // GET: tblItemDetails
        public ActionResult Index()
        {
            var tblItemDetails = db.tblItemDetails.Include(t => t.AspNetUser);
            return View(tblItemDetails.ToList());
        }

        // GET: tblItemDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemDetail tblItemDetail = db.tblItemDetails.Find(id);
            if (tblItemDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblItemDetail);
        }

        // GET: tblItemDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Name");
            return View();
        }

        // POST: tblItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,ItemName,Description,Quantity,Price")] tblItemDetail tblItemDetail)
        {
            if (ModelState.IsValid)
            {
                db.tblItemDetails.Add(tblItemDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Name", tblItemDetail.UserID);
            return View(tblItemDetail);
        }

        // GET: tblItemDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemDetail tblItemDetail = db.tblItemDetails.Find(id);
            if (tblItemDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Name", tblItemDetail.UserID);
            return View(tblItemDetail);
        }

        // POST: tblItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,ItemName,Description,Quantity,Price")] tblItemDetail tblItemDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItemDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Name", tblItemDetail.UserID);
            return View(tblItemDetail);
        }

        // GET: tblItemDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemDetail tblItemDetail = db.tblItemDetails.Find(id);
            if (tblItemDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblItemDetail);
        }

        // POST: tblItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItemDetail tblItemDetail = db.tblItemDetails.Find(id);
            db.tblItemDetails.Remove(tblItemDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
