using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem;

[Serializable]
public class DependencyNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DependencyNotFoundException() : base("Dependency was not found.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DependencyNotFoundException(string message) : base(message) { }
    
    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DependencyNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DependencyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}