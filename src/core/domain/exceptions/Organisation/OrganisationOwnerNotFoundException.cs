using System.Runtime.Serialization;

namespace domain.exceptions.Organisation;

[Serializable]
public class OrganisationOwnerNotFoundException :Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationOwnerNotFoundException() : base("The given Owner was not found for the Organisation.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationOwnerNotFoundException(string message) : base(message) { }
    
    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public OrganisationOwnerNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected OrganisationOwnerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}