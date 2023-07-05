using System;
using System.Collections.Generic;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class DboRole
    {
        public DboRole()
        {
            DboAccounts = new HashSet<DboAccount>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DboAccount> DboAccounts { get; set; }
    }
}
