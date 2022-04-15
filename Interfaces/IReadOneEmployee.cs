using tidepaykeeping_api.Models;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadOneEmployee
    {
         Employee Get(int id);
         Employee GetOne(string empEmail, string empPassword);
    }
}