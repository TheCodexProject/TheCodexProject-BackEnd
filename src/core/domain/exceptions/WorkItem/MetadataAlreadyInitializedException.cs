using System.Runtime.Serialization;

namespace domain.exceptions.WorkItem;

[Serializable]
public class MetadataAlreadyInitializedException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public MetadataAlreadyInitializedException() : base("Metadata has already been initalized for this work item.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public MetadataAlreadyInitializedException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public MetadataAlreadyInitializedException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MetadataAlreadyInitializedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}