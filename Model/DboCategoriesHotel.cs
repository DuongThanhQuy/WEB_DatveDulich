using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboCategoriesHotel
    {
        public DboCategoriesHotel()
        {
            DboHotels = new HashSet<DboHotel>();
        }

        public int CatHotelId { get; set; }
        public string CatHotelName { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public bool? Published { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public string Cover { get; set; }
        public string SchemaMarkup { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<DboHotel> DboHotels { get; set; }
    }
}
