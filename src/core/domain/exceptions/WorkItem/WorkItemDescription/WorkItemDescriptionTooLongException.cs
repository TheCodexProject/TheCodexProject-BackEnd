using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem.WorkItemDescription;

[Serializable]
public class WorkItemDescriptionTooLongException : Exception
{
    public WorkItemDescriptionTooLongException() : base("Description is too long, it cannot be more than 500 characters.") { }
    
    public WorkItemDescriptionTooLongException(string message) : base(message) { }
    
    public WorkItemDescriptionTooLongException(string message, Exception innerException) : base(message, innerException) { }
    
    protected WorkItemDescriptionTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}