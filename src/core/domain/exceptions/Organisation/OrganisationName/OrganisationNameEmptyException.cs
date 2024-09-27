using System.Runtime.Serialization;

namespace domain.exceptions.Organisation;

/// <summary>
/// Exception for when an Organisation is created without a title.
/// </summary>
[Serializable]
public class OrganisationNameEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationNameEmptyException() : base("Title cannot be empty, it must be between 2 and 100 characters.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationNameEmptyException(string message) : base(message) { }
    
    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public OrganisationNameEmptyException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected OrganisationNameEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}