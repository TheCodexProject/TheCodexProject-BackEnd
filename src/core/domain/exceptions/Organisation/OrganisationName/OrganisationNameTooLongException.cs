using System.Runtime.Serialization;

namespace domain.exceptions.Organisation;

[Serializable]
public class OrganisationNameTooLongException : Exception
{
    public OrganisationNameTooLongException() : base("Title is too long, it cannot be more than 100 characters.") { }
    
    public OrganisationNameTooLongException(string message) : base(message) { }
    
    public OrganisationNameTooLongException(string message, Exception innerException) : base(message, innerException) { }
    
    protected OrganisationNameTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}