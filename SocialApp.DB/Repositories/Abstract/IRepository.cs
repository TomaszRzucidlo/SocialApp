using SocialApp.DB.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.Repositories.Abstract
{
    public interface IRepository<T> where T : Entity
    {
        Task<IList<T>> GetListAsync();

        IQueryable<T> GetQueryable();

        Task<T> GetAsync(Guid id);

        Task<T> GetAndEnsureExistAsync(Guid id);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}
