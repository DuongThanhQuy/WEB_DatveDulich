using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboFlight
    {
        public DboFlight()
        {
            DboAttributesFlightPrices = new HashSet<DboAttributesFlightPrice>();
        }

        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int? CatFlightId { get; set; }
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
        public string From { get; set; }
        public string To { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public int? Seats { get; set; }
        public string Picture { get; set; }

        public virtual DboCategoriesFlight CatFlight { get; set; }
        public virtual ICollection<DboAttributesFlightPrice> DboAttributesFlightPrices { get; set; }
    }
}
