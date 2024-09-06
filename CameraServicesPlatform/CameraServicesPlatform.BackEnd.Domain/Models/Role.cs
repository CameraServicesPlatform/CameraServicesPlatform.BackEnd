using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Role
{
    [Key]
    public Guid RoleID { get; set; }

    [Required]
    [MaxLength(255)]
    public string RoleName { get; set; }

    public string RoleDescription { get; set; }

    public ICollection<Account> Accounts { get; set; }
    public ICollection<AccountRole> AccountRoles { get; set; }
 }