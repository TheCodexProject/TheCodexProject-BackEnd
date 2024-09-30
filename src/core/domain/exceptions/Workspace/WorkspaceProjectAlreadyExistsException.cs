using System.Runtime.Serialization;

namespace domain.exceptions.workspace;

[Serializable]
public class WorkspaceProjectAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceProjectAlreadyExistsException() : base("The workspace already exists in the workspace") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceProjectAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceProjectAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceProjectAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
