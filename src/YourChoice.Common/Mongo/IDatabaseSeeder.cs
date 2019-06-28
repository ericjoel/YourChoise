using System.Threading.Tasks;

namespace YourChoice.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}