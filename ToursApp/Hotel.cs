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
    
    public partial class Hotel
    {
        public Hotel()
        {
            this.HotelComment = new HashSet<HotelComment>();
            this.HotelImage = new HashSet<HotelImage>();
        }
    
        public int? id { get; set; }
        public string name { get; set; }
        public int countOfStars { get; set; }
        public string countryCode { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ICollection<HotelComment> HotelComment { get; set; }
        public virtual ICollection<HotelImage> HotelImage { get; set; }
    }
}
