using System.Runtime.Serialization;

namespace domain.exceptions.Workspace.WorkspaceTitle;


/// <summary>
/// Exception for when a WorkItem is created with a too short title
/// </summary>
[Serializable]
internal class WorkspaceTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleTooShortException() : base("Title is too short, it must be more then 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceTitleTooShortException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkspaceTitleTooShortException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkspaceTitleTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
