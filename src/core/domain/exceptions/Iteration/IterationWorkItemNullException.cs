using System.Runtime.Serialization;

namespace domain.exceptions.iteration;

[Serializable]
public class IterationWorkItemNullException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public IterationWorkItemNullException() : base("WorkItem cannot be null") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public IterationWorkItemNullException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public IterationWorkItemNullException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected IterationWorkItemNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
