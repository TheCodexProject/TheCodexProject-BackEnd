using System.Runtime.Serialization;

namespace domain.exceptions.iteration;

[Serializable]
public class IterationWorkItemNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public IterationWorkItemNotFoundException() : base("WorkItem not found in Iteration") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public IterationWorkItemNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public IterationWorkItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected IterationWorkItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
