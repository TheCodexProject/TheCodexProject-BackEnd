using System.Runtime.Serialization;

namespace domain.exceptions.documentation.documentationFormat;

/// <summary>
/// Exception for when a Documentation format does not start with a dot.
/// </summary>
[Serializable]
public class DocumentationFormatDoesNotStartWithDot : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationFormatDoesNotStartWithDot() : base("Format doesn't follow conventions, it must start with a dot.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationFormatDoesNotStartWithDot(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationFormatDoesNotStartWithDot(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationFormatDoesNotStartWithDot(SerializationInfo info, StreamingContext context) : base(info, context) { }
}