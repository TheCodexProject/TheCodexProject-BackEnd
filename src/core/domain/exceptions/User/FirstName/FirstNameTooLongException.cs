using System.Runtime.Serialization;

namespace domain.exceptions.User.FirstName;

[Serializable]
public class FirstNameTooLongException : Exception
{
    public FirstNameTooLongException() : base("Your first name is too long. Please enter a first name with no more than 25 characters." ) { }
    
    public FirstNameTooLongException(string message) : base(message) { }
    
    public FirstNameTooLongException(string message, Exception innerException) : base(message, innerException) { }
    
    protected FirstNameTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}