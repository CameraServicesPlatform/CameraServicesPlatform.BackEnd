using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Role
    {
        [Key]
        public string RoleID { get; set; } // Unique identifier for the role

        [Required]
        [MaxLength(255)]
        public string RoleName { get; set; }  

        public string RoleDescription { get; set; }  

         public Guid? AccountID { get; set; }  
        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; }  

        public Guid? AccountRoleID { get; set; }  
        [ForeignKey(nameof(AccountRoleID))]
        public AccountRole AccountRole { get; set; }  
    }
}
