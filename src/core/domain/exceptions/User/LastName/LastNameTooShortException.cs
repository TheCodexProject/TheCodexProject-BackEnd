using System.Runtime.Serialization;

namespace domain.exceptions.User.LastName;

[Serializable]
public class LastNameTooShortException : Exception
{
    public LastNameTooShortException() : base("Your last name is too short. Please enter at least 2 characters." ) { }
    
    public LastNameTooShortException(string message) : base(message) { }
    
    public LastNameTooShortException(string message, Exception innerException) : base(message, innerException) { }
    
    protected LastNameTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}