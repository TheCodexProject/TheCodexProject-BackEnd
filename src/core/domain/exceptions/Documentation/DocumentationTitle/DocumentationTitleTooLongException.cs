using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectTitle;

[Serializable]
public class DocumentationTitleTooLongException : Exception
{
    public DocumentationTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }

    public DocumentationTitleTooLongException(string message) : base(message) { }

    public DocumentationTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }

    protected DocumentationTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
} 