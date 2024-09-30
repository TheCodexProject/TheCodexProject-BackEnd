using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem;

using System;

[Serializable]
public class DocumentationNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationNotFoundException() : base("Documentation was not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

}