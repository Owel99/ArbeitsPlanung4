//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArbeitsPlanung4Lib
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flugzeug
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flugzeug()
        {
            this.hatArbeit = new HashSet<Arbeit>();
        }
    
        public int FlugzeugId { get; set; }
        public string Kennzeichen { get; set; }
        public string Typ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arbeit> hatArbeit { get; set; }
    }
}
