using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboAttributesFlightPrice
    {
        public int AttributesPriceFightId { get; set; }
        public int? AttributeId { get; set; }
        public int? Price { get; set; }
        public bool? Active { get; set; }
        public int FlightId { get; set; }

        public virtual DboAttribute Attribute { get; set; }
        public virtual DboFlight Flight { get; set; }
    }
}
