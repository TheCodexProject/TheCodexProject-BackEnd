using System.Runtime.Serialization;

namespace domain.exceptions.board.orderByExpression;

/// <summary>
/// Exception for when a OrderByExpression is created with null as input.
/// </summary>
[Serializable]
public class OrderByExpressionNullException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrderByExpressionNullException() : base("OrderByExpression cannot be null") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrderByExpressionNullException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public OrderByExpressionNullException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected OrderByExpressionNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
