//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class shape
    {
        public shape()
        {
            this.trips = new HashSet<trip>();
        }
    
        public string shape_id { get; set; }
        public Nullable<decimal> shape_pt_lat { get; set; }
        public Nullable<decimal> shape_pt_lon { get; set; }
        public int shape_pt_sequence { get; set; }
        public Nullable<double> shape_dist_traveled { get; set; }
    
        public virtual ICollection<trip> trips { get; set; }
    }
}