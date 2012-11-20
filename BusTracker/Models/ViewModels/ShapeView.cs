using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTracker.Models.ViewModels
{
    public class ShapeView
    {
        public List<double> shape_pt_lat { get; set; }
        public List<double> shape_pt_lon { get; set; }
        public List<int> shape_pt_sequence { get; set; }
    }
}