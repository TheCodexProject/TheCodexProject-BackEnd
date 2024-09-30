using System.Runtime.Serialization;

namespace domain.exceptions.board.boardTitle;

/// <summary>
/// Exception for when a Board is created with a title that are too long.
/// </summary>
[Serializable]
public class BoardTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardTitleTooLongException() : base("Title cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardTitleTooLongException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BoardTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BoardTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
