//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodDonationPoint.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patients()
        {
            this.BloodStorage = new HashSet<BloodStorage>();
        }
    
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fatherhood { get; set; }
        public Nullable<long> PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool BloodType { get; set; }
        public bool HepatitisBVirusAntigen { get; set; }
        public bool HepatitisCVirusAntigen { get; set; }
        public bool HepatitisCVirusAntibodies { get; set; }
        public bool HIVAntigen { get; set; }
        public bool HIVAntibodies { get; set; }
        public bool Syphilis { get; set; }
        public int ID_Doctors { get; set; }
        public string Blood { get; set; }
        public string RH { get; set; }
        public string MainImagePath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodStorage> BloodStorage { get; set; }
        public virtual Doctors Doctors { get; set; }

        public string ActualOblsedovania
        {
            get
            {
                return BloodType&& HepatitisBVirusAntigen&& HepatitisCVirusAntigen&& HepatitisCVirusAntibodies&& HIVAntigen&& HIVAntibodies&& Syphilis ? "Все" : "Не все";
            }
        }
    }
}
