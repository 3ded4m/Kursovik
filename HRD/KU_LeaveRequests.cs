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
    
    public partial class KU_LeaveRequests
    {
        public int RequestID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public Nullable<bool> IsNotified { get; set; }
    
        public virtual KU_Employees KU_Employees { get; set; }
    }
}
