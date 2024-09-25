using System.Runtime.Serialization;

namespace domain.exceptions.Organisation;

public class OrganisationNameTooShortException : Exception
{
    public OrganisationNameTooShortException() : base("Title is too short, it cannot be less than 2 characters.") { }
    
    public OrganisationNameTooShortException(string message) : base(message) { }
    
    public OrganisationNameTooShortException(string message, Exception innerException) : base(message, innerException) { }
    
    protected OrganisationNameTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}