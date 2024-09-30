using System.Runtime.Serialization;

namespace domain.exceptions.Board;

[Serializable]
public class BoardOrderByAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardOrderByAlreadyExistsException() : base("The Orderby already exists") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardOrderByAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BoardOrderByAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BoardOrderByAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

}
