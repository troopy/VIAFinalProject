using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;

namespace BusTracker.Controllers
{
    public class BaseController : Controller
    {
        public BLL.StopBLL stopBLL = new BLL.StopBLL();
        public GtfsDBEntities db = new GtfsDBEntities();
        //public gtfsDBcontext _db = new gtfsDBcontext();
       
    }
}
