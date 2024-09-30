using System.Runtime.Serialization;

namespace domain.exceptions.iteration;

[Serializable]
public class IterationWorkItemAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public IterationWorkItemAlreadyExistsException() : base("WorkItem already exists in the iteration") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public IterationWorkItemAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public IterationWorkItemAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected IterationWorkItemAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
