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
            IReadAllTimeReports timeReports = new ReadTimeReport();
            return timeReports.Get();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{empID}", Name="GetOneEmpsTimelog")]
        public TimeReport Get(string empID)
        {
            IReadAllTimeReports timeReports = new ReadTimeReport();
            return timeReports.Get(empID);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost(Name="PostTimeReport")]
        public void Post(TimeReport t)
        {
            // ICreateTimelog timelog = new CreateTimelog();
            // timelog.Create(t);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] TimeReport t)
        {
            // IUpdateTimelog timelog = new UpdateTimelog();
            // timelog.Update(t);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // IDeleteTimelog timelog = new DeleteTimelog();
            // timelog.Delete(id);
        }
    }
}
