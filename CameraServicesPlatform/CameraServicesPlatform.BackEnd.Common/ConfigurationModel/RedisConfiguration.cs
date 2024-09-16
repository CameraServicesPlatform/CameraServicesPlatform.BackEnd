using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.ConfigurationModel
{
    public class RedisConfiguration
    {
        public bool Enabled { get; set; }
        public string? ConnectionString { get; set; }
    }
}
