using tidepaykeeping_api.Models;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadOneTimelog
    {
         Timelog Get(int id);
    }
}