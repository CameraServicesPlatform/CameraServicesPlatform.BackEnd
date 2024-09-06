using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class AccountRole
    {
        [Key]
        public Guid AccountRoleID { get; set; }

        public Guid AccountID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; }

        public Guid RoleID { get; set; }

        [ForeignKey(nameof(RoleID))]
        public Role Role { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
