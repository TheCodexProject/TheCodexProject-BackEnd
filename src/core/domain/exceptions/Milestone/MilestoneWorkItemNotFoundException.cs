using System.Runtime.Serialization;

namespace domain.exceptions.milestone;

/// <summary>
/// Exception for when a Project is created without a title.
/// </summary>
[Serializable]
public class MilestoneWorkItemNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public MilestoneWorkItemNotFoundException() : base("Workitem not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public MilestoneWorkItemNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public MilestoneWorkItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MilestoneWorkItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}