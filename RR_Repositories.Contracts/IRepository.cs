using RR_Models.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RR_Repositories.Contracts
{

    public interface IRepository
    {
        Task<T> GetById<T>(int id, bool notActiveToo = false) where T : Entity;
        Task<IQueryable<T>> GetMany<T>(bool notActiveToo = false) where T : Entity;
        Task<IQueryable<T>> GetMany<T>(Expression<Func<T, bool>> predicate, bool notActiveToo = false) where T : Entity;
        Task<int> Insert<T>(T entity) where T : Entity;
        Task Update<T>(T entity) where T : Entity;
        Task Delete<T>(T entity) where T : Entity;
    }
}
