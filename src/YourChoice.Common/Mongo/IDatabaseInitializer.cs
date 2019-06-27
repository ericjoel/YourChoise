using System.Threading.Tasks;

namespace YourChoice.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}