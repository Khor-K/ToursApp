//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToursApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.Hotel = new HashSet<Hotel>();
            this.Tour = new HashSet<Tour>();
        }
    
        public string code { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Hotel> Hotel { get; set; }
        public virtual ICollection<Tour> Tour { get; set; }
    }
}