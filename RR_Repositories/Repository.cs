using Microsoft.EntityFrameworkCore;
using RR_Migration;
using RR_Models.Contracts;
using RR_Repositories.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RR_Repositories
{
    public abstract class Repository : IRepository
    {
        protected readonly EfCoreDbContext _dbContext;

        public Repository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual Task<T> GetById<T>(int id, bool notActiveToo = false) where T : Entity
        {
            return notActiveToo ?
                _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id) :
                _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public virtual Task<IQueryable<T>> GetMany<T>(bool notActiveToo = false) where T : Entity
        {
            return Task.FromResult(notActiveToo ?
                _dbContext.Set<T>() :
                _dbContext.Set<T>().Where(x => x.IsActive));
        }

        public virtual Task<IQueryable<T>> GetMany<T>(Expression<Func<T, bool>> predicate, bool notActiveToo = false) where T : Entity
        {
            return Task.FromResult(notActiveToo ?
                _dbContext.Set<T>().Where(predicate) :
                _dbContext.Set<T>().Where(x => x.IsActive).Where(predicate));
        }

        public Task<int> Insert<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().AddAsync(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Update<T>(T entity) where T : Entity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();

        }

        public Task Delete<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
