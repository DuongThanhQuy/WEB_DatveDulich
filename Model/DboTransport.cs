using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboTransport
    {
        public DboTransport()
        {
            DboAttributesTraPrices = new HashSet<DboAttributesTraPrice>();
        }

        public int TransportId { get; set; }
        public string TransportName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int? CatTraId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string Video { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? BestSellers { get; set; }
        public bool? HomeFlag { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public int? Amount { get; set; }
        public int? Seats { get; set; }
        public string RentalInfo { get; set; }
        public string Picture { get; set; }
        public string UnitslnStock { get; set; }

        public virtual DboCategoriesTra CatTra { get; set; }
        public virtual ICollection<DboAttributesTraPrice> DboAttributesTraPrices { get; set; }
    }
}
