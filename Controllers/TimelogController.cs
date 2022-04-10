﻿// using System.ComponentModel.DataAnnotations.Schema;
// using System.Net.Cache;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using tidepaykeeping_api.Database;
// using tidepaykeeping_api.Models;
// using tidepaykeeping_api.Interfaces;
// using Microsoft.AspNetCore.Cors;

// namespace tidepaykeeping_api.Controllers
// {
//     [ApiController]
//     [Route("tidepaykeeping-api/[controller]")]
//     public class TimelogController : ControllerBase
//     {
//         [EnableCors("AnotherPolicy")]
//         [HttpGet(Name = "GetTimelogs")]
//         // [HttpGet()
//         public List<Timelog> Get()
//         {
//             IReadAllEmployees employees = new ReadEmployee();
//             return employees.Get();
//         }

//         [EnableCors("AnotherPolicy")]
//         [HttpGet("{id}", Name="GetEmployee")]
//         public Employee Get(int id)
//         {
//             IReadOneEmployee employee = new ReadEmployee();
//             return employee.Get(id);
//         }

//         [EnableCors("AnotherPolicy")]
//         [HttpPost(Name="PostEmployee")]
//         public void Post(Employee e)
//         {
//             ICreateEmployee employee = new CreateEmployee();
//             employee.Create(e);
//         }

//         [EnableCors("AnotherPolicy")]
//         [HttpPut]
//         public void Put([FromBody] Employee e)
//         {
//             IUpdateEmployee employee = new UpdateEmployee();
//             employee.Update(e);
//         }

//         [EnableCors("AnotherPolicy")]
//         [HttpDelete("{id}")]
//         public void Delete(int id)
//         {
//             IDeleteEmployee employee = new DeleteEmployee();
//             employee.Delete(id);
//         }
//     }
// }
