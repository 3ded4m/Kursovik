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
    
    public partial class KU_Education
    {
        public int EducationID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public Nullable<int> GraduationYear { get; set; }
        public string Specialization { get; set; }
    
        public virtual KU_Employees KU_Employees { get; set; }
    }
}
