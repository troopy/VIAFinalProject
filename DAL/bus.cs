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
    
    public partial class bus
    {
        public int bus_id { get; set; }
        public Nullable<int> route_id { get; set; }
        public Nullable<decimal> bus_lat { get; set; }
        public Nullable<decimal> bus_lon { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual route route { get; set; }
    }
}
