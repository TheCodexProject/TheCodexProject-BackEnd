using System.Runtime.Serialization;

namespace domain.exceptions.iteration.iterationTitle;

/// <summary>
/// Exception for when a Iteration is created with a title that are too long.
/// </summary>
[Serializable]
public class IterationTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public IterationTitleTooLongException() : base("Title cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public IterationTitleTooLongException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public IterationTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected IterationTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
