using System;
using System.Threading.Tasks;
using YourChoice.Services.Activities.Domain.Models;

namespace YourChoice.Services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
    }
}