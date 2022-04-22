using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tidepaykeeping_api.Database;
using tidepaykeeping_api.Models;
using tidepaykeeping_api.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace tidepaykeeping_api.Controllers
{
    [ApiController]
    [Route("tidepaykeeping-api/[controller]")]
    public class TimeReportController : ControllerBase
    {
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetTimeReports")]
        public List<TimeReport> Get()
        {
            IReadAllTimeReports timereports = new ReadTimeReport();
            return timereports.Get();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{empID}", Name="GetTimelog")]
        public TimeReport Get(string empID)
        {
            IReadOneTimeReport timereport = new ReadTimeReport();
            return timereport.Get(empID);
        }

        // POST: api/TimeReport -async
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TimeReport -async/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/TimeReport -async/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
