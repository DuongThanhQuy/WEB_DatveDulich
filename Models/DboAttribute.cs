using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboAttribute
    {
        public DboAttribute()
        {
            DboAttributesCruisePrices = new HashSet<DboAttributesCruisePrice>();
            DboAttributesFlightPrices = new HashSet<DboAttributesFlightPrice>();
            DboAttributesHotelPrices = new HashSet<DboAttributesHotelPrice>();
            DboAttributesTourPrices = new HashSet<DboAttributesTourPrice>();
            DboAttributesTraPrices = new HashSet<DboAttributesTraPrice>();
        }

        public int AttributeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DboAttributesCruisePrice> DboAttributesCruisePrices { get; set; }
        public virtual ICollection<DboAttributesFlightPrice> DboAttributesFlightPrices { get; set; }
        public virtual ICollection<DboAttributesHotelPrice> DboAttributesHotelPrices { get; set; }
        public virtual ICollection<DboAttributesTourPrice> DboAttributesTourPrices { get; set; }
        public virtual ICollection<DboAttributesTraPrice> DboAttributesTraPrices { get; set; }
    }
}
