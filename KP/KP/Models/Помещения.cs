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
    
    public partial class Помещения
    {
        public int IDПомещения { get; set; }
        public Nullable<int> Площадь { get; set; }
        public Nullable<int> Этаж { get; set; }
        public Nullable<int> Номер { get; set; }
        public Nullable<int> IDЗдания { get; set; }
        public Nullable<int> IDАрендодатель { get; set; }
    
        public virtual Арендодатель Арендодатель { get; set; }
        public virtual Здания Здания { get; set; }
    }
}
