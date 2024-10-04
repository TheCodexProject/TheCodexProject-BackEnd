using Microsoft.Extensions.DependencyInjection;

namespace application.Extensions;

public static class ApplicationExtensions
{
    public static void RegisterCommandHandlers(this IServiceCollection services)
    {
        // TODO: Register command handlers here like this:
        // services.AddScoped<ICommandHandler<CreateWorkItemHandler>,CreateWorkItemHandler>();
    }


    public static void RegisterCommandDispatcher(this IServiceCollection services)
    {
        // TODO: Register command dispatcher here like this:
        // services.AddScoped<ICommandDispatcher, CommandDispatcher>();
    }
}