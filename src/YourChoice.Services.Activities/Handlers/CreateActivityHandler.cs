using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RawRabbit;
using YourChoice.Common.Commands;
using YourChoice.Common.Events;
using YourChoice.Common.Exceptions;
using YourChoice.Services.Activities.Services;

namespace YourChoice.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;
        private readonly ILogger _logger;

        public CreateActivityHandler(IBusClient busClient,
            IActivityService activityService,
            ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }
        
        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity {command.Name}");
            try
            {
                await _activityService.AddAsync(command.Id, command.UserId, command.Category, command.Name,
                    command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category,
                    command.Name, command.Description, command.CreatedAt));
                return;
            }
            catch (YourChoiceException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, ex.Message, ex.Code));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, "error", ex.Message));
                _logger.LogError(ex.Message);
            }
        }
    }
}