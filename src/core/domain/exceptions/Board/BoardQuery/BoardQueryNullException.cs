using System.Runtime.Serialization;

namespace domain.exceptions.board.boardQuery;

/// <summary>
/// Exception for when a Board is created without a BoardQuery.
/// </summary>
[Serializable]
public class BoardQueryNullException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardQueryNullException() : base("BoardQuery cannot be null") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardQueryNullException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BoardQueryNullException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BoardQueryNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
