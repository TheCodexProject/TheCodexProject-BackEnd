using System.Runtime.Serialization;

namespace domain.exceptions.workspace;

[Serializable]
public class WorkspaceContactAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceContactAlreadyExistsException() : base("The contact already exists in the workspace") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceContactAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceContactAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceContactAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
