using System.Runtime.Serialization;

namespace domain.exceptions.Workspace.WorkspaceTitle;

/// <summary>
/// Exception for when a Workspace is created without a title.
/// </summary>
[Serializable]
internal class WorkspaceTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleEmptyException() : base("Title cannot be empty") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceTitleEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceTitleEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceTitleEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
