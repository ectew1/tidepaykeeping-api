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
        [HttpGet("{empID}/{startDate}/{endDate}", Name="GetAllTimeReports")]
        public List<TimeReport> Get(string empID, DateTime startDate, DateTime endDate)
        {
            IReadAllTimeReports timeReports = new ReadTimeReport();
            return timeReports.Get(empID, startDate, endDate);
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{empID}/{startDate}/{endDate}/{i}", Name="GetSortedReport")]
        public List<TimeReport> Get(string empID, DateTime startDate, DateTime endDate, int i)
        {
            IReadAllTimeReports timeReports = new ReadTimeReport();
            System.Console.WriteLine("made it 1.0");
            return timeReports.Get(empID, startDate, endDate, i);
        }
        
        [EnableCors("AnotherPolicy")]
        [HttpGet("{startDate}/{endDate}", Name="ManagerTimeReports")]
        public List<TimeReport> Get(DateTime startDate, DateTime endDate)
        {
            IReadAllTimeReports timeReports = new ReadTimeReport();
            return timeReports.Get(startDate, endDate);
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
