using System.Runtime.Serialization;

namespace domain.exceptions.User.Email;

[Serializable]
public class EmailEmptyException : Exception
{
    public EmailEmptyException() : base("Email is empty, please provide an email.") { }
    
    public EmailEmptyException(string message) : base(message) { }
    
    public EmailEmptyException(string message, Exception innerException) : base(message, innerException) { }
    
    protected EmailEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    
}