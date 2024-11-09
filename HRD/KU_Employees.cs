//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRD
{
    using System;
    using System.Collections.Generic;
    
    public partial class KU_Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KU_Employees()
        {
            this.KU_Contacts = new HashSet<KU_Contacts>();
            this.KU_Education = new HashSet<KU_Education>();
            this.KU_EmployeeChildren = new HashSet<KU_EmployeeChildren>();
            this.KU_EmployeeProfessionalData = new HashSet<KU_EmployeeProfessionalData>();
            this.KU_SalaryHistory = new HashSet<KU_SalaryHistory>();
            this.KU_Users = new HashSet<KU_Users>();
            this.KU_EmployeeOfTheMonth = new HashSet<KU_EmployeeOfTheMonth>();
            this.KU_Tasks = new HashSet<KU_Tasks>();
            this.KU_LeaveRequests = new HashSet<KU_LeaveRequests>();
            this.KU_HRRequests = new HashSet<KU_HRRequests>();
        }
    
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public string PlaceOfResidence { get; set; }
        public string PlaceOfRegistration { get; set; }
        public string MaritalStatus { get; set; }
        public Nullable<int> ChildrenCount { get; set; }
        public string EmploymentStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_Contacts> KU_Contacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_Education> KU_Education { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_EmployeeChildren> KU_EmployeeChildren { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_EmployeeProfessionalData> KU_EmployeeProfessionalData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_SalaryHistory> KU_SalaryHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_Users> KU_Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_EmployeeOfTheMonth> KU_EmployeeOfTheMonth { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_Tasks> KU_Tasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_LeaveRequests> KU_LeaveRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KU_HRRequests> KU_HRRequests { get; set; }
    }
}