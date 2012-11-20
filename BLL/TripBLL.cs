using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TripBLL : Base
    {
        public List<string> getBusstopsNameByRouteID(int route_id)
        {
            var trips = (from s in db.trips where s.route_id == route_id select s).First();
            var stoptimes = (from st in db.stop_times where st.trip_id == trips.trip_id select st.stop_id).ToArray();
          
            var routestops = (from D in db.stops
                      where stoptimes.Contains(D.stop_id)
                      select D.stop_name);
                  
            return routestops.ToList();
        }
        public List<double> getBusstopsLatByRouteID(int route_id)
        {
            var trips = (from s in db.trips where s.route_id == route_id select s).First();
            var stoptimes = (from st in db.stop_times where st.trip_id == trips.trip_id select st.stop_id).ToArray();

            var routestops = (from D in db.stops
                              where stoptimes.Contains(D.stop_id)
                              select (double)D.stop_lat);

            return routestops.ToList();
        }
        public List<double> getBusstopsLonByRouteID(int route_id)
        {
            var trips = (from s in db.trips where s.route_id == route_id select s).First();
            var stoptimes = (from st in db.stop_times where st.trip_id == trips.trip_id select st.stop_id).ToArray();

            var routestops = (from D in db.stops
                              where stoptimes.Contains(D.stop_id)
                              select (double)D.stop_lon);

            return routestops.ToList();
        }
    }
}
