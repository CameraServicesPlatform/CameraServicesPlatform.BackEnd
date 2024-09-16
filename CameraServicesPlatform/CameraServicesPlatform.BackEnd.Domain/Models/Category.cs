using System;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }

        [MaxLength(255)]
        public string CategoryName { get; set; }

        [MaxLength(500)]  
        public string? CategoryDescription { get; set; }

     }
}
