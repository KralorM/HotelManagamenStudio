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
    
    public partial class bookings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bookings()
        {
            this.payments = new ObservableCollection<payments>();
        }
    
        public int booking_id { get; set; }
        public Nullable<int> guest_id { get; set; }
        public Nullable<int> room_id { get; set; }
        public string price { get; set; }
        public Nullable<System.DateTime> check_in { get; set; }
    
        public virtual guests guests { get; set; }
        public virtual rooms rooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<payments> payments { get; set; }
    }
}
