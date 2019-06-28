using System;
using System.Threading.Tasks;
using YourChoice.Common.Exceptions;
using YourChoice.Services.Activities.Domain.Models;
using YourChoice.Services.Activities.Domain.Repositories;

namespace YourChoice.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;
        
        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }
        
        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(name);

            if (activityCategory == null)
                throw new YourChoiceException("category_not_found", $"Category: '{category} was not found." );

            var activity = new Activity(id, activityCategory, userId, name, description, createdAt);
            
            await _activityRepository.AddAsync(activity);
        }
    }
}