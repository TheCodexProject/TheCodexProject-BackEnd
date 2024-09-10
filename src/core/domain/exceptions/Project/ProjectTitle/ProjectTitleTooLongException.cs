using System.Runtime.Serialization;

namespace domain.exceptions.Project.ProjectTitle;

[Serializable]
public class ProjectTitleTooLongException : Exception
{
    public ProjectTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }

    public ProjectTitleTooLongException(string message) : base(message) { }

    public ProjectTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }

    protected ProjectTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}