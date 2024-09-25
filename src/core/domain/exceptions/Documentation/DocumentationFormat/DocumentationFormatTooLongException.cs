using System.Runtime.Serialization;

namespace domain.exceptions.documentation.documentationFormat;

[Serializable]
public class DocumentationFormatTooLongException : Exception
{
    public DocumentationFormatTooLongException() : base("Format is too long, it cannot be more than 5 characters.") { }

    public DocumentationFormatTooLongException(string message) : base(message) { }

    public DocumentationFormatTooLongException(string message, Exception innerException) : base(message, innerException) { }

    protected DocumentationFormatTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}