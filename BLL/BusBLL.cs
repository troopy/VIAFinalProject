using DAL;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BusBLL : Base
    {
        public void changeBusLocation(int bus_id, double bus_lat,double bus_lon)
        {
            var query= (from b in db.buses where b.bus_id == bus_id select b).Single();
            query.bus_lat = (decimal)bus_lat;
            query.bus_lon = (decimal)bus_lon;

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
        }
       
    }
}
