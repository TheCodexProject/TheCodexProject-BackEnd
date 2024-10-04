using application.AppEntry.Interfaces;
using OperationResult;

namespace application.AppEntry;

internal class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public Task<Result> DispatchAsync<TCommand>(TCommand command)
    {
        Type serviceType = typeof(ICommandHandler<TCommand>);
        var service = serviceProvider.GetService(serviceType);
        if (service is null)
        {
            throw new NullReferenceException($"Service not found: {nameof(ICommandHandler<TCommand>)}");
        }

        ICommandHandler<TCommand> handler = (ICommandHandler<TCommand>)service;
        return handler.HandleAsync(command);
    }



}