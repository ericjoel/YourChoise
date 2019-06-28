using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using YourChoice.Services.Activities.Domain.Models;
using YourChoice.Services.Activities.Domain.Repositories;
using MongoDB.Driver.Linq;

namespace YourChoice.Services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository

    {
        private readonly IMongoDatabase _database;
        
        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Activity> GetAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");
    }
}