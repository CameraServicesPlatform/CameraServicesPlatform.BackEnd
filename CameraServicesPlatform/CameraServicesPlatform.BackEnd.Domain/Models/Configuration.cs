using System;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Configuration
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(255)]  
        public string Name { get; set; } = null!;

        [MaxLength(255)] 
        public string PreValue { get; set; } = null!;

        [MaxLength(255)] 
        public string ActiveValue { get; set; } = null!;

        public DateTime ActiveDate { get; set; }
    }
}
