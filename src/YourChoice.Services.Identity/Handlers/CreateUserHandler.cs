using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RawRabbit;
using YourChoice.Common.Commands;

namespace YourChoice.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IBusClient busClient,
            ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _logger = logger;
        }
        
        public Task HandleAsync(CreateUser command)
        {
            throw new System.NotImplementedException();
        }
    }
}