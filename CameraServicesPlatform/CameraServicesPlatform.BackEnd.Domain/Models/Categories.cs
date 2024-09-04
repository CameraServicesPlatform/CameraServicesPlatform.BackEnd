using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Categories
    {
    [Key]  public Guid CategoryID { get; set; }
        public string CategoryName { get; set; } 
        public string CategoryDescription { get; set; }
    }

