//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Course.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostManDB
    {
        public PostManDB()
        {
            this.Id = 1;
            this.RegionDB = new HashSet<RegionDB>();
        }
    
        public int Id { get; set; }
        public string Surname { get; set; }
    
        public virtual PostalOfficeDB PostalOfficeDB { get; set; }
        public virtual ICollection<RegionDB> RegionDB { get; set; }
    }
}
