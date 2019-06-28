using System;
using System.Threading.Tasks;
using YourChoice.Services.Identity.Domain.Model;

namespace YourChoice.Services.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}