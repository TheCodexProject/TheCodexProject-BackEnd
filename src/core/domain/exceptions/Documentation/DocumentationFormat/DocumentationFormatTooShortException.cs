using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectTitle;

/// <summary>
/// Exception for when a Documentation format is too short.
/// </summary>
[Serializable]
public class DocumentationFormatTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationFormatTooShortException() : base("Format is too short, it cannot be less than 2 characters, including the dot.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationFormatTooShortException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationFormatTooShortException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationFormatTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}