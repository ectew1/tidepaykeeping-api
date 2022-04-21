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
    public class TimelogController : ControllerBase
    {
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetTimelogs")]
        public List<Timelog> Get()
        {
            IReadAllTimelogs timelogs = new ReadTimelog();
            return timelogs.Get();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name="GetTimelog")]
        public Timelog Get(int id)
        {
            IReadOneTimelog timelog = new ReadTimelog();
            return timelog.Get(id);
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{empID}/{clockOut}", Name="GetOpenTimelog")]
        public Timelog Get(string empID, DateTime clockOut)
        {
            IReadOneTimelog timelog = new ReadTimelog();
            return timelog.GetOpenTimelog(empID, clockOut);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost(Name="PostTimelog")]
        public void Post(Timelog t)
        {
            ICreateTimelog timelog = new CreateTimelog();
            timelog.Create(t);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Timelog t)
        {
            IUpdateTimelog timelog = new UpdateTimelog();
            timelog.Update(t);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteTimelog timelog = new DeleteTimelog();
            timelog.Delete(id);
        }
    }
}

