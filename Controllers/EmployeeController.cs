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
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Cors;

namespace tidepaykeeping_api.Controllers
{
    [ApiController]
    [Route("tidepaykeeping-api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetEmployees")]
        public List<Employee> Get()
        {
            IReadAllEmployees employees = new ReadEmployee();
            return employees.Get();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name="GetEmployee")]
        public Employee Get(int id)
        {
            IReadOneEmployee employee = new ReadEmployee();
            return employee.Get(id);
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{empEmail}/{empPassword}", Name="GetEmailandPassword")]
        public Employee Get(string empEmail, string empPassword)
        {
            IReadOneEmployee employee = new ReadEmployee();
            return employee.GetOne(empEmail, empPassword);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost(Name="PostEmployee")]
        public void Post(Employee e)
        {
            ICreateEmployee employee = new CreateEmployee();
            employee.Create(e);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Employee e)
        {
            IUpdateEmployee employee = new UpdateEmployee();
            employee.Update(e);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteEmployee employee = new DeleteEmployee();
            employee.Delete(id);
        }
    }
}

