//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaskiPlacowe.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SL_TYPOW_POL_PP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SL_TYPOW_POL_PP()
        {
            this.PaskiPlacowe_POZ = new HashSet<PaskiPlacowe_POZ>();
        }
    
        public long ID_TYPU_POLA { get; set; }
        public string KOD { get; set; }
        public string NAZWA { get; set; }
        public bool UNIKALNY { get; set; }
        public long ID_GRUPY { get; set; }
    
        public virtual SL_GRUPY_TYPOW_POL_PP SL_GRUPY_TYPOW_POL_PP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaskiPlacowe_POZ> PaskiPlacowe_POZ { get; set; }
    }
}
