using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectDescription;

[Serializable]
public class ProjectDescriptionTooLongException : Exception
{
    public ProjectDescriptionTooLongException() : base("Description is too long, it cannot be more than 500 characters.") { }

    public ProjectDescriptionTooLongException(string message) : base(message) { }

    public ProjectDescriptionTooLongException(string message, Exception innerException) : base(message, innerException) { }

    protected ProjectDescriptionTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}