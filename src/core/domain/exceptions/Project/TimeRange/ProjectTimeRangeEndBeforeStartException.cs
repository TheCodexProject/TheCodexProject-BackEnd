using System.Runtime.Serialization;

namespace domain.exceptions.project.TimeRange;

[Serializable]
public class ProjectTimeRangeEndBeforeStartException : Exception
{
    public ProjectTimeRangeEndBeforeStartException() : base("End time cannot be before Start time.") { }

    public ProjectTimeRangeEndBeforeStartException(string message) : base(message) { }

    public ProjectTimeRangeEndBeforeStartException(string message, Exception innerException) : base(message, innerException) { }

    protected ProjectTimeRangeEndBeforeStartException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}