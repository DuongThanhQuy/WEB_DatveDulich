using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboAttributesHotelPrice
    {
        public int AttributesPriceHotelId { get; set; }
        public int? AttributeId { get; set; }
        public int? Price { get; set; }
        public bool? Active { get; set; }
        public int HotelId { get; set; }

        public virtual DboAttribute Attribute { get; set; }
        public virtual DboHotel Hotel { get; set; }
    }
}
