using System.Runtime.Serialization;

namespace domain.exceptions.workspace;

[Serializable]
public class WorkspaceDocumentAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceDocumentAlreadyExistsException() : base("The document already exists in the workspace") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceDocumentAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceDocumentAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceDocumentAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
