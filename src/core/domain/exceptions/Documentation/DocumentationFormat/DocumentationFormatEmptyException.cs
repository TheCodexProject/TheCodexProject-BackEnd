using System.Runtime.Serialization;

namespace domain.exceptions.documentation.documentationFormat;

/// <summary>
/// Exception for when a Project is created without a title.
/// </summary>
[Serializable]
public class DocumentationFormatEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationFormatEmptyException() : base("Format cannot be empty, it must be between 2 and 10 characters, including the dot.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationFormatEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationFormatEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationFormatEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}