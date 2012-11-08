using BusTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace BusTracker.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            StopView mv = new StopView();
            mv.stop_name = stopBLL.getStopNameByID(5);

            //ShapeView sv = new ShapeView();


            //List<ShapePoint> m = (from s in db.shapes where s.shape_id == "Line1" select new ShapePoint {shape_pt_lat = (double)s.shape_pt_lat, shape_pt_lon = (double)s.shape_pt_lon, shape_pt_sequence = s.shape_pt_sequence }).ToList();
            return View(mv);
        }
        

    }
    /*
    public class ShapePoint{

     
         public double shape_pt_lat { get; set; }
         public double shape_pt_lon { get; set; }
         public int shape_pt_sequence { get; set; }
    }
   */
}
