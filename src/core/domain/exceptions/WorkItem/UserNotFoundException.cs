using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem;

[Serializable]
public class UserNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public UserNotFoundException() : base("User was not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public UserNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}