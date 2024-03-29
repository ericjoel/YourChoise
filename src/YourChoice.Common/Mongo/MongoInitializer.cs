using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace YourChoice.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private readonly bool _seed;
        private bool _initiliazed;
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSeeder _seeder;

        public MongoInitializer(IMongoDatabase database,
            IOptions<MongoOptions> options,
            IDatabaseSeeder seeder)
        {
            _seeder = seeder;
            _database = database;
            _seed = options.Value.Seed;
        }
        public async Task InitializeAsync()
        {
            if (_initiliazed)
                return;

            RegisterConventions();
            _initiliazed = true;
            
            if (!_seed)
                return;
            
            await _seeder.SeedAsync();
        }

        private static void RegisterConventions()
        {
            ConventionRegistry.Register("YourChoiceConventions", new MongoConvention(), x => true);
        }

        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions { get; } = new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}