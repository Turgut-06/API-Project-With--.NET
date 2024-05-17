using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Infrastructure.RedisCache
{
    public class RedisCacheSettings
    {
        public string ConnectionString { get; set; } //redise bağlanmamızı sağlayacak
        public string InstanceName { get; set; } //redis database'in isminin ne olacağı
    }
}
