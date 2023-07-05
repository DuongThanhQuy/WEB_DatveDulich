using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboAttributesTourPrice
    {
        public int AttributesPriceTourD { get; set; }
        public int? AttributeId { get; set; }
        public int? Price { get; set; }
        public bool? Active { get; set; }
        public int TourId { get; set; }

        public virtual DboAttribute Attribute { get; set; }
        public virtual DboTour Tour { get; set; }
    }
}
