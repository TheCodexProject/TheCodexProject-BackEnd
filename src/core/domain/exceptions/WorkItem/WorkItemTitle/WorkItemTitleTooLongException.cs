using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem.WorkItemTitle;

[Serializable]
public class WorkItemTitleTooLongException : Exception
{
    public WorkItemTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }
    
    public WorkItemTitleTooLongException(string message) : base(message) { }
    
    public WorkItemTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }
    
    protected WorkItemTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}