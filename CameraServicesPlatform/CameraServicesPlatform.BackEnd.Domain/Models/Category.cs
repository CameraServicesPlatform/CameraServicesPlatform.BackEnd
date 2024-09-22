using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }


        public string CategoryName { get; set; }


        public string? CategoryDescription { get; set; }

    }
}
