using System.Runtime.Serialization;

namespace domain.exceptions.Board;

[Serializable]
public class BoardFilterNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardFilterNotFoundException() : base("Filter not found in Board") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardFilterNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BoardFilterNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BoardFilterNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
