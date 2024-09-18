//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace CameraServicesPlatform.BackEnd.Domain.Models
//{
//    public class Role
//    {
//        [Key]
//        public Guid RoleID { get; set; }  

//        [MaxLength(255)]
//        public string RoleName { get; set; }  

//        public string RoleDescription { get; set; }

//        [ForeignKey(nameof(AccountID))]
//        public Guid? AccountID { get; set; }  
//        public Account Account { get; set; }

//        [ForeignKey(nameof(AccountRoleID))]
//        public Guid? AccountRoleID { get; set; }  
//        public AccountRole AccountRole { get; set; }  
//    }
//}
