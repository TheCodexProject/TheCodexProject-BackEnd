using System.Runtime.Serialization;

namespace domain.exceptions.documentation.documentationFormat;

/// <summary>
/// Exception for when a Project is created without a title.
/// </summary>
[Serializable]
public class DocumentationFormatDoesNotFollowConventionException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationFormatDoesNotFollowConventionException() : base("Format doesn't follow conventions, it must contain atleast a dot and a single character.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationFormatDoesNotFollowConventionException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationFormatDoesNotFollowConventionException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationFormatDoesNotFollowConventionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}