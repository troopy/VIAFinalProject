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
    public class AgencyController : Controller
    {
        private GtfsDBEntities db = new GtfsDBEntities();

        //
        // GET: /Agency/

        public ViewResult Index()
        {
            return View(db.agencies.ToList());
        }

        //
        // GET: /Agency/Details/5

        public ViewResult Details(int id)
        {
            agency agency = db.agencies.Find(id);
            return View(agency);
        }

        //
        // GET: /Agency/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Agency/Create

        [HttpPost]
        public ActionResult Create(agency agency)
        {
            if (ModelState.IsValid)
            {
                db.agencies.Add(agency);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(agency);
        }
        
        //
        // GET: /Agency/Edit/5
 
        public ActionResult Edit(int id)
        {
            agency agency = db.agencies.Find(id);
            return View(agency);
        }

        //
        // POST: /Agency/Edit/5

        [HttpPost]
        public ActionResult Edit(agency agency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agency);
        }

        //
        // GET: /Agency/Delete/5
 
        public ActionResult Delete(int id)
        {
            agency agency = db.agencies.Find(id);
            return View(agency);
        }

        //
        // POST: /Agency/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            agency agency = db.agencies.Find(id);
            db.agencies.Remove(agency);
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