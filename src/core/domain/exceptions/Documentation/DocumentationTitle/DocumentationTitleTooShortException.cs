using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectTitle;

[Serializable]
public class DocumentationTitleTooShortException : Exception
{
    public DocumentationTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }

    public DocumentationTitleTooShortException(string message) : base(message) { }

    public DocumentationTitleTooShortException(string message, Exception innerException) : base(message, innerException) { }

    protected DocumentationTitleTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}