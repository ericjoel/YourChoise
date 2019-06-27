using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe.Middleware;
using YourChoice.Common.Commands;
using YourChoice.Common.Events;

namespace YourChoice.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler)
            where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(cfg =>
                    cfg.FromQueue(GetQueueName<TCommand>())));
        
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler)
            where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(cfg =>
                    cfg.FromQueue(GetQueueName<TEvent>())));

        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly()?.GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("RabbitMq");
            section.Bind(options);

            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            service.AddSingleton<IBusClient>(_ => client);
        }
    }
}