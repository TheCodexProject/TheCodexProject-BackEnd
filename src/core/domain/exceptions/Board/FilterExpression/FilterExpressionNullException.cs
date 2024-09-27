using System.Runtime.Serialization;

namespace domain.exceptions.board.filterExpression;

/// <summary>
/// Exception for when a FilterExpression is created with null as input.
/// </summary>
[Serializable]
public class FilterExpressionNullException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public FilterExpressionNullException() : base("FilterExpression cannot be null") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public FilterExpressionNullException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public FilterExpressionNullException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected FilterExpressionNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
