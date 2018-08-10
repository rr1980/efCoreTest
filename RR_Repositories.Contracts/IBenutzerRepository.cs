using RR_Models;
using System.Linq;
using System.Threading.Tasks;

namespace RR_Repositories.Contracts
{
    public interface IBenutzerRepository
    {
        Task<IQueryable<Benutzer>> GetAll(bool notActiveToo = false);
        Task<int> Add(Benutzer benutzer);
    }
}
