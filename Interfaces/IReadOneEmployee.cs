using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Interfaces
{
    public interface IReadOneEmployee
    {
         Employee Get(int id);
    }
}