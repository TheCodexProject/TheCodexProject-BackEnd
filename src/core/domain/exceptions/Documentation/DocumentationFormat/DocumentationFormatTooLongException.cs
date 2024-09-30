using System.Runtime.Serialization;

namespace domain.exceptions.documentation.documentationFormat;

/// <summary>
/// Exception for when a Documentation format is too long.
/// </summary>
[Serializable]
public class DocumentationFormatTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationFormatTooLongException() : base("Format is too long, it cannot be more than 10 characters, including the dot.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationFormatTooLongException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationFormatTooLongException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationFormatTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}