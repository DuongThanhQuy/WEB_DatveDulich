using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboTour
    {
        public DboTour()
        {
            DboAttributesTourPrices = new HashSet<DboAttributesTourPrice>();
        }

        public int TourId { get; set; }
        public string TourName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int? CatTourId { get; set; }
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
        public int? Seats { get; set; }
        public int? Amount { get; set; }
        public int? Duration { get; set; }
        public string Picture { get; set; }

        public virtual DboCategoriesTour CatTour { get; set; }
        public virtual ICollection<DboAttributesTourPrice> DboAttributesTourPrices { get; set; }
    }
}
