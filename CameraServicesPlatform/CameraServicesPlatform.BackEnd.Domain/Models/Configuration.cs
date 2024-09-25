using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Configuration
    {
        [Key]
        public Guid Id { get; set; }


        public string Name { get; set; } = null!;


        public string PreValue { get; set; } = null!;


        public string ActiveValue { get; set; } = null!;

        public DateTime ActiveDate { get; set; }
    }
}
