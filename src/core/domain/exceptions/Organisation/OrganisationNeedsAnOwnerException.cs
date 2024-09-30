using System.Runtime.Serialization;

namespace domain.exceptions.Organisation;

[Serializable]
public class OrganisationNeedsAnOwnerException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationNeedsAnOwnerException() : base("The Organisation needs atleast 1 Owner") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationNeedsAnOwnerException(string message) : base(message) { }
    
    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public OrganisationNeedsAnOwnerException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected OrganisationNeedsAnOwnerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}