using System.Collections.Generic;
using tidepaykeeping_api.Models;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadAllEmployees
    {
        List<Employee> Get();
        
        // Employee Get(string empEmail, string empPassword);
    }
}