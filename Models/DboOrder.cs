using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboOrder
    {
        public DboOrder()
        {
            DboOrderDetails = new HashSet<DboOrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? TravelDate { get; set; }
        public int? TransactStatusId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentId { get; set; }
        public string Note { get; set; }

        public virtual DboCustomer Customer { get; set; }
        public virtual DboTransactStatus TransactStatus { get; set; }
        public virtual ICollection<DboOrderDetail> DboOrderDetails { get; set; }
    }
}
