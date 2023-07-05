using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboLocation
    {
        public DboLocation()
        {
            DboCustomers = new HashSet<DboCustomer>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        public string NameWithType { get; set; }
        public string PathWithType { get; set; }
        public int? ParentCode { get; set; }
        public int? Level { get; set; }

        public virtual ICollection<DboCustomer> DboCustomers { get; set; }
    }
}
