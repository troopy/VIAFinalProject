using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ShapeBLL : Base
    {
        public List<double> getShapeLatByRouteID(int route_id)
        {
            var trip = (from r in db.trips where r.route_id == route_id select r).First();
            return (from s in db.shapes
                    where trip.shape_id == s.shape_id
                    select (double)s.shape_pt_lat).ToList();
        }
        public List<double> getShapeLonByRouteID(int route_id)
        {
            var trip = (from r in db.trips where r.route_id == route_id select r).First();
            return (from s in db.shapes
                    where trip.shape_id == s.shape_id
                    select (double)s.shape_pt_lon).ToList();
        }
        public List<int> getShapeSequenceByRouteID(int route_id)
        {
            var trip = (from r in db.trips where r.route_id == route_id select r).First();
            return (from s in db.shapes
                    where trip.shape_id == s.shape_id
                    select s.shape_pt_sequence).ToList();
        }

    }
}
