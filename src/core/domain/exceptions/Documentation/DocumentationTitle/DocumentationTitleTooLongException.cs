using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectTitle;

/// <summary>
/// Exception for when a documentation title is too long.
/// </summary>
[Serializable]
public class DocumentationTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationTitleTooLongException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
} 