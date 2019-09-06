using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HA.DNS.Business;
using HA.DNS.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNS_HousingAnywhere.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DNSController : ControllerBase
    {
        public DNSController(DNSService dnsService)
        {
            _dnsService = dnsService;
        }
        private readonly DNSService _dnsService;
        // GET api/values
        [HttpPost]
        public async Task<ActionResult<DnsResponse>> GetBankLocation([FromBody] DnsRequest coords)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Keys);
            }
            try
            {
                var locationResponse = await _dnsService.GetDataBankLocation(coords).ConfigureAwait(false);
                return Ok(locationResponse);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
