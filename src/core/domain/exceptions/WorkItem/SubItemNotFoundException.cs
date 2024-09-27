using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem;

[Serializable]
public class SubItemNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public SubItemNotFoundException() : base("Sub Items was not found.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public SubItemNotFoundException(string message) : base(message) { }
    
    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public SubItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SubItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}