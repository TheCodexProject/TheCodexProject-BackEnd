using System.Runtime.Serialization;

namespace domain.exceptions.documentation.documentationContent;

/// <summary>
/// Exception for when a Documentation is created without content.
/// </summary>
[Serializable]
public class DocumentationContentEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationContentEmptyException() : base("Content reference cannot be empty") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationContentEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationContentEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationContentEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}