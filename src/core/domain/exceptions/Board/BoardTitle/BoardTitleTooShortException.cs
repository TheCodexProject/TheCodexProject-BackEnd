using System.Runtime.Serialization;

namespace domain.exceptions.board.boardTitle;

/// <summary>
/// Exception for when a Board is created with a too short title
/// </summary>
[Serializable]
public class BoardTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardTitleTooShortException() : base("Title is too short, it must be more then 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardTitleTooShortException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BoardTitleTooShortException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BoardTitleTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
