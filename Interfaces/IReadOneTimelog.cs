using tidepaykeeping_api.Models;
using tidepaykeeping_api.Database;
using System.Collections.Generic;
using System;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadOneTimelog
    {
         Timelog Get(int id);
         Timelog GetOpenTimelog(string empID, DateTime clockOut);
    }
}