using System.Runtime.Serialization;

namespace domain.exceptions.Project.TimeRange;

[Serializable]
public class ProjectTimeRangeStartAfterEndException : Exception
{
    public ProjectTimeRangeStartAfterEndException() : base("Start time cannot be after End time.") { }

    public ProjectTimeRangeStartAfterEndException(string message) : base(message) { }

    public ProjectTimeRangeStartAfterEndException(string message, Exception innerException) : base(message, innerException) { }

    protected ProjectTimeRangeStartAfterEndException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}