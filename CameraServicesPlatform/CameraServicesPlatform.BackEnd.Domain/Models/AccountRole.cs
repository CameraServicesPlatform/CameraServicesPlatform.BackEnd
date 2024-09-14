using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class AccountRole
    {
        [Key]
        public Guid AccountRoleID { get; set; }

        [ForeignKey(nameof(Account))]
        public string AccountID { get; set; }  

        public virtual Account Account { get; set; }

        [ForeignKey(nameof(Role))]
        public Guid RoleID { get; set; } 

        public virtual Role Role { get; set; }
    }
}
