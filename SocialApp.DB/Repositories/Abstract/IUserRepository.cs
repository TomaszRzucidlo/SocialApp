using SocialApp.DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
