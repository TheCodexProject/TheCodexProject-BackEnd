using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectTitle;

/// <summary>
/// Exception for when a Project is created without a title.
/// </summary>
[Serializable]
public class ProjectTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTitleEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public ProjectTitleEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected ProjectTitleEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}