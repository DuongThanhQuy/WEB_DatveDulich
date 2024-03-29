﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboCustomer
    {
        public DboCustomer()
        {
            DboOrders = new HashSet<DboOrder>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? LocationId { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? Active { get; set; }
        public byte[] Image { get; set; }

        public virtual DboLocation Location { get; set; }
        public virtual ICollection<DboOrder> DboOrders { get; set; }
    }
}
