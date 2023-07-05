using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboCruise
    {
        public DboCruise()
        {
            DboAttributesCruisePrices = new HashSet<DboAttributesCruisePrice>();
        }

        public int CruiseId { get; set; }
        public string CruiseName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int? CatId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
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
        public int? Seats { get; set; }
        public string Duration { get; set; }
        public int? Amount { get; set; }
        public byte[] Image { get; set; }

        public virtual DboCategory Cat { get; set; }
        public virtual ICollection<DboAttributesCruisePrice> DboAttributesCruisePrices { get; set; }
    }
}
