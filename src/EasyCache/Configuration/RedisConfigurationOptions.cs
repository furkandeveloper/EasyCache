using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.Configuration
{
    public class RedisConfigurationOptions
    {
        public string Configuration { get; set; }

        public string InstanceName { get; set; }
    }
}
