using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem;

[Serializable]
public class SubItemAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public SubItemAlreadyExistsException() : base("The given Sub-item is already present on the Work Item.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public SubItemAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public SubItemAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SubItemAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}