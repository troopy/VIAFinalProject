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

        public ActionResult Index()
        {
            //StopView mv = new StopView();
            //mv.stop_name = stopBLL.getStopNameByID(5);
       
          //  List<string> ime = tr.getBusstopsByRouteID(1);
          

            //List<ShapePoint> m = (from s in db.shapes where s.shape_id == "Line1" select new ShapePoint {shape_pt_lat = (double)s.shape_pt_lat, shape_pt_lon = (double)s.shape_pt_lon, shape_pt_sequence = s.shape_pt_sequence }).ToList();
            return View();
        }
          [HttpPost]
        public Lon latlon(Lon model)
        {
               BusBLL busbl = new BusBLL();
              busbl.changeBusLocation(2,Double.Parse(model.lat),Double.Parse(model.lon));
            return model;
        }
          [HttpPost]
          public JsonResult drawRoutes(string Data)
          {
              ShapeBLL shapebl = new ShapeBLL();
              RouteBLL routebl = new RouteBLL();
            
              var res = new { lat = shapebl.getShapeLatByRouteID(int.Parse(Data)).ToArray(), lon = shapebl.getShapeLonByRouteID(int.Parse(Data)).ToArray(), color = routebl.getColorByRouteID(int.Parse(Data))  };
              return Json(res);

          }
          [HttpPost]
          public JsonResult drawStops(string Data)
          {
              TripBLL tripbl = new TripBLL();

              var res = new { lat = tripbl.getBusstopsLatByRouteID(int.Parse(Data)).ToArray(), lon = tripbl.getBusstopsLonByRouteID(int.Parse(Data)).ToArray() };
              return Json(res);

          } 
          }
    }

    public class Lons{ 
        public double[] lat { get; set; }
        public double[] lon { get; set; }
    }
    public class Lon
    {
        public string lat { get; set; }
        public string lon { get; set; }
    }
public class JsonResponseFactory

{

 public static object ErrorResponse(string error) {
 return new { Success = false, ErrorMessage = error };

 }

public static object SuccessResponse() {

 return new { Success = true};

 }

public static object SuccessResponse(object referenceObject)

 {
 return new { Success = true, Object = referenceObject };
 }

}

