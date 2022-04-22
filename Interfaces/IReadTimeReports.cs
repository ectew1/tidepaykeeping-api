using tidepaykeeping_api.Models;
using tidepaykeeping_api.Database;
using System.Collections.Generic;
using System;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadTimeReports
    {
        List<TimeReport> Get();
        TimeReport Get(string empID);
        // Timelog GetOpenTimelog(string empID, DateTime clockOut);
    }
}