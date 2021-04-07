using LibraryApi.Controllers;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class RedisOnCallDeveloperLookup : ILookupOnCallDevelopers
    {
        private readonly IDistributedCache _cache;

        public RedisOnCallDeveloperLookup(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<OnCallDeveloperResponse> GetOnCallDeveloperAsync()
        {
            var cachedResponse = await _cache.GetAsync("oncall");

            if (cachedResponse != null)
            {
                var storedResponse = Encoding.UTF8.GetString(cachedResponse);
                var response = JsonSerializer.Deserialize<OnCallDeveloperResponse>(storedResponse);

                return response;
            }
            else
            {
                var dev = new OnCallDeveloperResponse
                {
                    Name = "Bob",
                    Email = "Bob@None.Com",
                    Until = DateTime.Today.AddDays(7),
                };

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(15));

                var data = JsonSerializer.Serialize(dev);
                var encoded = Encoding.UTF8.GetBytes(data);
                await _cache.SetAsync("oncall", encoded, options);

                return dev;
            }
        }
    }
}
