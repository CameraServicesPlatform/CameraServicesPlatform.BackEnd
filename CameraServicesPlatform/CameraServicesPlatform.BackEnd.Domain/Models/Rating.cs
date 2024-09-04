using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Rating
    {
    [Key]
    public Guid RatingID { get; set; }

    public Guid ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }

    public Guid UserID { get; set; }

    [ForeignKey(nameof(UserID))]
    public User User { get; set; }

    public int RatingValue { get; set; }

    public string ReviewComment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

