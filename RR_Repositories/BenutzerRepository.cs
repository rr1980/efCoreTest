using RR_Common.Exceptions;
using RR_Migration;
using RR_Models;
using RR_Repositories.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace RR_Repositories
{
    public class BenutzerRepository : Repository, IBenutzerRepository
    {
        public BenutzerRepository(EfCoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> Add(Benutzer benutzer)
        {
            var exists = await GetMany<Benutzer>(x => x.UserName == benutzer.UserName);

            if (exists.Any())
            {
                throw new EntityExistsException<Benutzer>(benutzer, x => x.UserName);
            }

            return await Insert(benutzer);
        }

        public Task<IQueryable<Benutzer>> GetAll(bool notActiveToo = false)
        {
            return GetMany<Benutzer>();
        }
    }
}
