using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using YourChoice.Common.Mongo;
using YourChoice.Services.Activities.Domain.Models;
using YourChoice.Services.Activities.Domain.Repositories;

namespace YourChoice.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CustomMongoSeeder(IMongoDatabase database,
            ICategoryRepository categoryRepository) : base(database)
        {
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work",
                "sport",
                "hobby"
            };

            await Task.WhenAll(categories.Select(x => _categoryRepository.AddAsync(new Category(x))));
        }
    }
}