using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class CachingController : ControllerBase
    {
        private readonly ILookupOnCallDevelopers _onCallDeveloperLookup;

        public CachingController(ILookupOnCallDevelopers onCallDeveloperLookup)
        {
            _onCallDeveloperLookup = onCallDeveloperLookup;
        }

        [HttpGet("/ServerTime")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 10)]
        public ActionResult GetTheTime()
        {
            return Ok(new { ServerTime = DateTime.Now });
        }

        [HttpGet("/oncalldeveloper")]
        public async Task<ActionResult> GetOnCallDeveloper()
        {
            var response = await _onCallDeveloperLookup.GetOnCallDeveloperAsync();
            return Ok(response);
        }
    }

    public class OnCallDeveloperResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Until { get; set; }
    }
}
