//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HHS_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblKlasgroep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblKlasgroep()
        {
            this.tblStudents = new HashSet<tblStudent>();
        }
    
        public int klasgroep_id { get; set; }
        [Required]
        [StringLength(60)]
        public string naam { get; set; }
        [Required]
        [StringLength(5)]
        public string klascode { get; set; }
        public Nullable<int> richting_id { get; set; }
        public Nullable<int> docent_id { get; set; }
    
        public virtual tblDocent tblDocent { get; set; }
        public virtual tblRichting tblRichting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStudent> tblStudents { get; set; }
    }
}
