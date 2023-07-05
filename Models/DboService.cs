using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboService
    {
        public DboService()
        {
            DboAttributesPrices = new HashSet<DboAttributesPrice>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int? CatId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string Thumb { get; set; }
        public string Video { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool BestSellers { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public int? UnitslnStock { get; set; }

        public virtual DboCategory Cat { get; set; }
        public virtual ICollection<DboAttributesPrice> DboAttributesPrices { get; set; }
    }
}
