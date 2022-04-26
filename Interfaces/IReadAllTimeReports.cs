using tidepaykeeping_api.Models;
using tidepaykeeping_api.Database;
using System.Collections.Generic;
using System;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadAllTimeReports
    {
        List<TimeReport> Get();
        TimeReport Get(string empID);
        List<TimeReport> Get(string empID, DateTime startDate, DateTime endDate);
        List<TimeReport> Get(DateTime startDate, DateTime endDate);
    }
}