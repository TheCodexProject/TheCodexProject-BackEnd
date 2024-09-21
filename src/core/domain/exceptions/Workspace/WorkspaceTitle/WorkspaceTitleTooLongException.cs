using System.Runtime.Serialization;

namespace domain.exceptions.Workspace.WorkspaceTitle;

/// <summary>
/// Exception for when a Workspace is created with a title that are too long.
/// </summary>
[Serializable]
public class WorkspaceTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleTooLongException() : base("Title cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceTitleTooLongException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
