using System.Runtime.Serialization;

namespace domain.exceptions.board.boardTitle;

/// <summary>
/// Exception for when a Board is created without a title.
/// </summary>
[Serializable]
public class BoardTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardTitleEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BoardTitleEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BoardTitleEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
