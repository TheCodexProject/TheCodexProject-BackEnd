using System.Runtime.Serialization;

namespace domain.exceptions.User.FirstName;

[Serializable]
public class FirstNameEmptyException : Exception
{
    public FirstNameEmptyException() : base("Your first name is missing. Please provide your first name." ) { }
    
    public FirstNameEmptyException(string message) : base(message) { }
    
    public FirstNameEmptyException(string message, Exception innerException) : base(message, innerException) { }
    
    protected FirstNameEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}