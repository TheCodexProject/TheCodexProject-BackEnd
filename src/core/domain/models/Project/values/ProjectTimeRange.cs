using domain.exceptions.project.TimeRange;
using domain.models.workItem.values;
using OperationResult;

namespace domain.models.project.values;

public class ProjectTimeRange
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    public DateTime[] dateTimes { get; private set; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private ProjectTimeRange() { }

    /// <summary>
    /// The private constructor for the <see cref="ProjectTimeRange"/> class.
    /// </summary>
    /// <param name="start, end"></param>
    private ProjectTimeRange(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
        dateTimes = [start, end];
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="ProjectTimeRange"/> class.
    /// </summary>
    /// <param name="start, end">Title to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<ProjectTimeRange> Create(DateTime start, DateTime end)
    {
        var result = Validate(start, end);

        if (result.IsFailure)
        {
            return Result<ProjectTimeRange>.Failure(result.Errors.ToArray());
        }

        var timeRange = new ProjectTimeRange(start, end);

        return timeRange;
    }

    /// <summary>
    /// Validates the time range.
    /// </summary>
    /// <param name="start, end">Description to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(DateTime start, DateTime end)
    {
        var errors = new List<Exception>();

        // ? Start date is after end date
        if (start.Date > end.Date)
        {
            errors.Add(new ProjectTimeRangeStartAfterEndException());
        }

        // ? Start time is after end time
        if (start.TimeOfDay > end.TimeOfDay)
        {
            errors.Add(new ProjectTimeRangeEndBeforeStartException());
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Equality operator for the <see cref="ProjectTimeRange"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is ProjectTimeRange timeRange)
        {
            if (timeRange.Start == Start && timeRange.End == End)
                {  return true; }
        }

        return false;
    }
}