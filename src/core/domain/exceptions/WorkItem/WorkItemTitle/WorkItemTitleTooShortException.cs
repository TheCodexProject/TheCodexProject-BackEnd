using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem.WorkItemTitle;

[Serializable]
public class WorkItemTitleTooShortException : Exception
{
    public WorkItemTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }
    
    public WorkItemTitleTooShortException(string message) : base(message) { }
    
    public WorkItemTitleTooShortException(string message, Exception innerException) : base(message, innerException) { }
    
    protected WorkItemTitleTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}