﻿using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }

        [Required]
        [Index(IsUnique = true)]   
        public string CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        public bool StatusCategory { get; set; }
    }
}


