using System.Runtime.Serialization;

namespace domain.exceptions.Project.ProjectTitle;

public class ProjectTitleTooShortException : Exception
{
    public ProjectTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }

    public ProjectTitleTooShortException(string message) : base(message) { }

    public ProjectTitleTooShortException(string message, Exception innerException) : base(message, innerException) { }

    protected ProjectTitleTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}