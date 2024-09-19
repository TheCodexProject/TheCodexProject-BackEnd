using System.Runtime.Serialization;

namespace domain.exceptions.Id;

[Serializable]
public class IdConversionExpection : Exception
{
    public IdConversionExpection() : base("The conversion of the Id failed.") { }
    
    public IdConversionExpection(string message) : base(message) { }
    
    public IdConversionExpection(string message, Exception innerException) : base(message, innerException) { }
    
    protected IdConversionExpection(SerializationInfo info, StreamingContext context) : base(info, context) { }
}