//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagamenStudio
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class employees
    {
        public int employee_id { get; set; }
        public Nullable<int> room_id { get; set; }
        public Nullable<System.DateTime> hire_date { get; set; }
        public string Position { get; set; }
        public Nullable<decimal> salary { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    
        public virtual rooms rooms { get; set; }
    }
}
