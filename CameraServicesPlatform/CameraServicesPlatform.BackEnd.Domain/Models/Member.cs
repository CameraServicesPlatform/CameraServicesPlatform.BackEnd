using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Member
{
    [Key]
    public Guid MemberID { get; set; }

    [ForeignKey("Account")]
    public Guid AccountID { get; set; }

    public Account Account { get; set; }
 
    public DateTime JoinedAt { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("Wishlist")]
    public Guid? WishlistID { get; set; }  
    public Wishlist Wishlist { get; set; }   

    [ForeignKey("OrderHistory")]
    public Guid? OrderHistoryID { get; set; }   
    public OrderHistory OrderHistory { get; set; }
}