using System.Runtime.Serialization;

namespace domain.exceptions.milestone;

/// <summary>
/// Exception for when a Project is created without a title.
/// </summary>
[Serializable]
public class MilestoneWorkItemErrorException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public MilestoneWorkItemErrorException() : base("WorkItem cannot be added or removed from a Milestone because it is not valid.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public MilestoneWorkItemErrorException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public MilestoneWorkItemErrorException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MilestoneWorkItemErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}