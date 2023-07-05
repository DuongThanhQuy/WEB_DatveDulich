using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboAttributesTraPrice
    {
        public int AttributesPriceTraId { get; set; }
        public int? AttributeId { get; set; }
        public int? Price { get; set; }
        public bool? Active { get; set; }
        public int TransportId { get; set; }

        public virtual DboAttribute Attribute { get; set; }
        public virtual DboTransport Transport { get; set; }
    }
}
