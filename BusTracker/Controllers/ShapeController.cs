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
    public class ShapeController : Controller
    {
        private GtfsDBEntities db = new GtfsDBEntities();

        //
        // GET: /Shape/

        public ViewResult Index()
        {
            return View(db.shapes.ToList());
        }

        //
        // GET: /Shape/Details/5

        public ViewResult Details(int id)
        {
            shape shape = db.shapes.Find(id);
            return View(shape);
        }

        //
        // GET: /Shape/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Shape/Create

        [HttpPost]
        public ActionResult Create(shape shape)
        {
            if (ModelState.IsValid)
            {
                db.shapes.Add(shape);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(shape);
        }


        
        //
        // GET: /Shape/Edit/5
 
        public ActionResult Edit(int id)
        {
            shape shape = db.shapes.Find(id);
            return View(shape);
        }

        //
        // POST: /Shape/Edit/5

        [HttpPost]
        public ActionResult Edit(shape shape)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shape).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shape);
        }

        //
        // GET: /Shape/Delete/5
 
        public ActionResult Delete(int id)
        {
            shape shape = db.shapes.Find(id);
            return View(shape);
        }

        //
        // POST: /Shape/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            shape shape = db.shapes.Find(id);
            db.shapes.Remove(shape);
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