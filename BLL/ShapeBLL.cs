using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ShapeBLL : Base
    {
        public string getShapeByID(string shape_id)
        {
            return null;// (from s in db.shapes where s.shape_id == shape_id select new ShapeView { shape_pt_lat = (double)s.shape_pt_lat, shape_pt_lon = (double)s.shape_pt_lon, shape_pt_sequence = s.shape_pt_sequence }).ToList();
        }
    }
}
