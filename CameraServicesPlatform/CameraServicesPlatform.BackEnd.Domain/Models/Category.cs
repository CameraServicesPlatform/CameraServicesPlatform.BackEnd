using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Category
    {
    [Key]
    public Guid CategoryID { get; set; }

    [MaxLength(255)]
    public string CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}

