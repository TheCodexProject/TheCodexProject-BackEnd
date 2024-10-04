using OperationResult;

namespace application.AppEntry.Interfaces;

public interface ICommandDispatcher
{
    Task<Result> DispatchAsync<TCommand>(TCommand command);
}