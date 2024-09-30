using System.Runtime.Serialization;

namespace domain.exceptions.Board;

[Serializable]
public class BoardOrderByNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardOrderByNotFoundException() : base("OrderBy not found in Board") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardOrderByNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BoardOrderByNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BoardOrderByNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
