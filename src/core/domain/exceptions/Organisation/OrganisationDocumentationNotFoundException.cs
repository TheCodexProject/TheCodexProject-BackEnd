using System.Runtime.Serialization;

namespace domain.exceptions.Organisation;

[Serializable]
public class OrganisationDocumentationNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationDocumentationNotFoundException() : base("Documentation was not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationDocumentationNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public OrganisationDocumentationNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected OrganisationDocumentationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}