using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboAttributesCruisePrice
    {
        public int AttributesPriceCruiseId { get; set; }
        public int? AttributeId { get; set; }
        public int? Price { get; set; }
        public bool? Active { get; set; }
        public int CruiseId { get; set; }

        public virtual DboAttribute Attribute { get; set; }
        public virtual DboCruise Cruise { get; set; }
    }
}
