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
    
    public partial class PostalOfficeDB
    {
        public PostalOfficeDB()
        {
            this.Id = 1;
        }
    
        public int Id { get; set; }
        public string TitlePostal { get; set; }
    
        public virtual SubEditionDB SubEditionDB { get; set; }
        public virtual PostManDB PostManDB { get; set; }
        public virtual SubscriberDB SubscriberDB { get; set; }
        public virtual RegionDB RegionDB { get; set; }
    }
}
