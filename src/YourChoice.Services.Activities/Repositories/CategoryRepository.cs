using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using YourChoice.Services.Activities.Domain.Models;
using YourChoice.Services.Activities.Domain.Repositories;
using MongoDB.Driver.Linq;

namespace YourChoice.Services.Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;
        
        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Category> GetAsync(string name)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());

        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection.AsQueryable().ToListAsync();

        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);

        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");
    }
}