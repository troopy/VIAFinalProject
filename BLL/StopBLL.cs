using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class StopBLL : Base
    {
        public string getStopNameByID(int stopid)
        {
            return (from s in db.stops where stopid == s.stop_id select s.stop_name).Single(); 
        }
    }
}
