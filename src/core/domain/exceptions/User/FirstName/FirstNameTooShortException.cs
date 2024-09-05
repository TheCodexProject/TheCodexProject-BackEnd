using System.Runtime.Serialization;

namespace domain.exceptions.User.FirstName;

[Serializable]
public class FirstNameTooShortException : Exception
{
    public FirstNameTooShortException() : base("Your first name is too short. Please enter at least 2 characters." ) { }
    
    public FirstNameTooShortException(string message) : base(message) { }
    
    public FirstNameTooShortException(string message, Exception innerException) : base(message, innerException) { }
    
    protected FirstNameTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}