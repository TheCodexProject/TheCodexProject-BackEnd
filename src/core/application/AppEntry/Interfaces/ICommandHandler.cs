using OperationResult;

namespace application.AppEntry.Interfaces;

public interface ICommandHandler<in TCommand>
{
    Task<Result> HandleAsync(TCommand command);
}