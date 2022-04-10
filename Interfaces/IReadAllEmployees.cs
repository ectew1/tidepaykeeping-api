using System.Collections.Generic;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadAllEmployees
    {
       List<Employee> Get();
         
    }
}