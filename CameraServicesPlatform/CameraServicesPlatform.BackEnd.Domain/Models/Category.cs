using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }


        public required string CategoryName { get; set; }


        public string? CategoryDescription { get; set; }

    }
}
