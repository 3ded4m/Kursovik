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
    
    public partial class KU_EmployeeOfTheMonth
    {
        public int EmployeeOfTheMonthID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime MonthAssigned { get; set; }
    
        public virtual KU_Employees KU_Employees { get; set; }
    }
}
