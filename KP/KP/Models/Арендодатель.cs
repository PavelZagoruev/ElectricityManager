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
    
    public partial class Арендодатель
    {
        public Арендодатель()
        {
            this.Помещения = new HashSet<Помещения>();
        }
    
        public string Наименование { get; set; }
        public string ПочтовыеДанные { get; set; }
        public Nullable<int> IDПомещения { get; set; }
        public Nullable<int> IDЗдания { get; set; }
        public Nullable<int> IDСотрудника { get; set; }
        public Nullable<int> IDДоговор { get; set; }
        public int IDАрендодатель { get; set; }
    
        public virtual ICollection<Помещения> Помещения { get; set; }
        public virtual Договор Договор { get; set; }
        public virtual Здания Здания { get; set; }
        public virtual Сотрудники Сотрудники { get; set; }
    }
}
