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
    
    public partial class KU_EmployeeProfessionalData
    {
        public int ProfessionalDataID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Position { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<int> TotalExperience { get; set; }
    
        public virtual KU_Employees KU_Employees { get; set; }
    }
}