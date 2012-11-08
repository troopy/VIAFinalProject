using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace BusTracker.Controllers
{ 
    public class StopController : BaseController
    {
        //private GtfsDBEntities db = new GtfsDBEntities();

        //
        // GET: /Stop/

        public ViewResult Index()
        {
            return View(db.stops.ToList());
        }

        //
        // GET: /Stop/Details/5

        public ViewResult Details(int id)
        {
            stop stop = db.stops.Find(id);
            return View(stop);
        }

        //
        // GET: /Stop/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Stop/Create

        [HttpPost]
        public ActionResult Create(stop stop)
        {
            if (ModelState.IsValid)
            {
                db.stops.Add(stop);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(stop);
        }
        
        //
        // GET: /Stop/Edit/5
 
        public ActionResult Edit(int id)
        {
            stop stop = db.stops.Find(id);
            return View(stop);
        }

        //
        // POST: /Stop/Edit/5

        [HttpPost]
        public ActionResult Edit(stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stop);
        }

        //
        // GET: /Stop/Delete/5
 
        public ActionResult Delete(int id)
        {
            stop stop = db.stops.Find(id);
            return View(stop);
        }

        //
        // POST: /Stop/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            stop stop = db.stops.Find(id);
            db.stops.Remove(stop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}