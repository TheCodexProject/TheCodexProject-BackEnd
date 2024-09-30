using System.Runtime.Serialization;

namespace domain.exceptions.Organisation;

[Serializable]
public class OrganisationDocumentationAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationDocumentationAlreadyExistsException() : base("Documentation was not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationDocumentationAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public OrganisationDocumentationAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected OrganisationDocumentationAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}