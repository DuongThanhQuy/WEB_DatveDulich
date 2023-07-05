using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboHotel
    {
        public DboHotel()
        {
            DboAttributesHotelPrices = new HashSet<DboAttributesHotelPrice>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int? CatHotelId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string Video { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool BestSellers { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public int? UnitslnStock { get; set; }
        public string Bed { get; set; }
        public string Address { get; set; }
        public string Rate { get; set; }
        public string Picture { get; set; }

        public virtual DboCategoriesHotel CatHotel { get; set; }
        public virtual ICollection<DboAttributesHotelPrice> DboAttributesHotelPrices { get; set; }
    }
}
