using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectTitle;

[Serializable]
public class DocumentationFormatTooShortException : Exception
{
    public DocumentationFormatTooShortException() : base("Format is too short, it cannot be less than 2 characters, including the dot.") { }

    public DocumentationFormatTooShortException(string message) : base(message) { }

    public DocumentationFormatTooShortException(string message, Exception innerException) : base(message, innerException) { }

    protected DocumentationFormatTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}