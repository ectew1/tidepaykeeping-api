using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Interfaces
{
    public interface ICreateTimelog
    {
         void Create(Timelog timelog);
    }
}