using System.Runtime.Serialization;

namespace domain.exceptions.User.LastName;

[Serializable]
public class LastNameTooLongException : Exception
{
    public LastNameTooLongException() : base("Your last name is too long. Please enter a last name with no more than 60 characters." ) { }
    
    public LastNameTooLongException(string message) : base(message) { }
    
    public LastNameTooLongException(string message, Exception innerException) : base(message, innerException) { }
    
    protected LastNameTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}