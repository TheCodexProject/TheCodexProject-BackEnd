using System.Runtime.Serialization;

namespace domain.exceptions.Workspace;

[Serializable]
public class WorkspaceOwnerEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceOwnerEmptyException() : base("The Workspace is missing a Owner.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceOwnerEmptyException(string message) : base(message) { }
    
    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceOwnerEmptyException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceOwnerEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}