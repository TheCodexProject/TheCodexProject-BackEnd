using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem.WorkItemTitle;

/// <summary>
/// Exception for when a WorkItem is created without a title.
/// </summary>
[Serializable]
public class WorkItemTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkItemTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkItemTitleEmptyException(string message) : base(message) { }
    
    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public WorkItemTitleEmptyException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected WorkItemTitleEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}