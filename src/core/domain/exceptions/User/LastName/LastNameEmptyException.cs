using System.Runtime.Serialization;

namespace domain.exceptions.User.LastName;

[Serializable]
public class LastNameEmptyException : Exception
{
    public LastNameEmptyException() : base("Your last name is missing. Please provide your last name." ) { }
    
    public LastNameEmptyException(string message) : base(message) { }
    
    public LastNameEmptyException(string message, Exception innerException) : base(message, innerException) { }
    
    protected LastNameEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}