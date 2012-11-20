using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RouteBLL : Base
    {
        public string getColorByRouteID(int route_id)
        {
            return (from s in db.routes where route_id == s.route_id select s.route_color).Single();
        }
    }
}