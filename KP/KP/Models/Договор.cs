//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Договор
    {
        public Договор()
        {
            this.Арендатор = new HashSet<Арендатор>();
            this.Арендодатель = new HashSet<Арендодатель>();
        }
    
        public int IDДоговор { get; set; }
        public Nullable<System.DateTime> ДатаВъезда { get; set; }
        public Nullable<System.DateTime> ДатаВыеда { get; set; }
        public string ИнформацияПоПомещению { get; set; }
    
        public virtual ICollection<Арендатор> Арендатор { get; set; }
        public virtual ICollection<Арендодатель> Арендодатель { get; set; }
    }
}
