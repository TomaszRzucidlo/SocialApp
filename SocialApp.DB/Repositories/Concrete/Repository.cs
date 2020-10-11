using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Domain.Concrete;
using SocialApp.DB.Entities.Abstract;
using SocialApp.DB.Exceptions;
using SocialApp.DB.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly SocialAppDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(SocialAppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IList<T>> GetListAsync()
            => await dbSet.ToListAsync();

        public IQueryable<T> GetQueryable()
            => dbSet.AsQueryable()
                .AsNoTracking();

        public async Task<T> GetAsync(Guid id)
            => await dbSet.FindAsync(id);

        public async Task<T> GetAndEnsureExistAsync(Guid id)
        {
            var result = await dbSet.FindAsync(id);
            if (result == null)
            {
                throw new AppException(ErrorCode.NotFound);
            }

            return result;
        }

        public async Task AddAsync(T entity)
            => await Task.FromResult(dbSet.Add(entity));

        public async Task UpdateAsync(T entity)
            => await Task.FromResult(dbSet.Update(entity));

        public async Task DeleteAsync(T entity)
            => await Task.FromResult(dbSet.Remove(entity));

        public async Task SaveChangesAsync()
        {
            if (await context.SaveChangesAsync() < 0)
            {
                throw new Exception("Cannot save changes in db.");
            }
        }
    }
}
