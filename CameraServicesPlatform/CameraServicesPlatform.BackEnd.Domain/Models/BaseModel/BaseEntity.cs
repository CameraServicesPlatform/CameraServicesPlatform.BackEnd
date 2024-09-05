using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models.BaseModel;
    public abstract class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateBy { get; set; } = null!;

        [ForeignKey(nameof(CreateBy))]
        public Account? CreateByAccount { get; set; }
        public string? UpdateBy { get; set; }

        [ForeignKey(nameof(UpdateBy))]
        public Account? UpdateByAccount { get; set; }
    }
