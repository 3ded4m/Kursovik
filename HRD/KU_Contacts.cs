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
    
    public partial class KU_Contacts
    {
        public int ContactID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressType { get; set; }
        public string Address { get; set; }
    
        public virtual KU_Employees KU_Employees { get; set; }
    }
}
