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
    
    public partial class KU_SalaryHistory
    {
        public int SalaryID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public decimal SalaryAmount { get; set; }
        public System.DateTime SalaryDate { get; set; }
        public string Note { get; set; }
    
        public virtual KU_Employees KU_Employees { get; set; }
    }
}