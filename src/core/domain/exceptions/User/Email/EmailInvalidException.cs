using System.Runtime.Serialization;

namespace domain.exceptions.User.Email;

[Serializable]
public class EmailInvalidException : Exception
{
    public EmailInvalidException() : base("Email is invalid, please provide a valid email.") { }
    
    public EmailInvalidException(string message) : base(message) { }
    
    public EmailInvalidException(string message, Exception innerException) : base(message, innerException) { }
    
    protected EmailInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    
}