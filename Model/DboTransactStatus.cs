using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Model
{
    public partial class DboTransactStatus
    {
        public DboTransactStatus()
        {
            DboOrders = new HashSet<DboOrder>();
        }

        public int TransactStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DboOrder> DboOrders { get; set; }
    }
}
