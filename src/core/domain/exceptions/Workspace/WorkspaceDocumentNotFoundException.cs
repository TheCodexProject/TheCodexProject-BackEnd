using System.Runtime.Serialization;

namespace domain.exceptions.workspace;

[Serializable]
public class WorkspaceDocumentNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceDocumentNotFoundException() : base("Document was not found") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceDocumentNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceDocumentNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceDocumentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
