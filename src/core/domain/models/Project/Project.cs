using domain.models.Project.values;
using domain.models.Users;
using domain.models.workItem;
using domain.models.workItem.values;
using OperationResult;

namespace domain.models.Project;

public class Project
{
    public Guid Id { get; set; }

    public ProjectTitle ProjectTitle { get; set; }

    public ProjectDescription? ProjectDescription { get; set; }

    public DateTime? ProjectStartTime { get; set; }

    public DateTime? ProjectEndTime { get; set; }

    public ProjectMethodology? ProjectMethodology { get; set; }

    public ProjectStatus? ProjectStatus { get; set; }

    public ProjectPriority? ProjectPriority { get; set; }

    private Project()
    {
        // "Specific" values
        Id = Guid.NewGuid();
    }

    public static Project Create()
    {
        // ! No validation needed here
        // As the WorkItem can be modified through the provided methods.
        return new Project();
    }

    public Result UpdateTitle(string title)
    {
        var newTitle = ProjectTitle.Create(title);

        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the title?
        if (newTitle.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(newTitle.Errors.ToArray());
        }

        // Update the title.
        ProjectTitle = newTitle.Value;

        // Update the updated at and updated by properties.
        //UpdatedAt = DateTime.UtcNow;
        // TODO: Include the user who updated thee work item.

        return Result.Success();
    }

    public Result UpdateDescription(string description)
    {
        var newDescription = ProjectDescription.Create(description);

        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the description?
        if (newDescription.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(newDescription.Errors.ToArray());
        }

        // Update the description.
        ProjectDescription = newDescription.Value;

        // Update the updated at and updated by properties.
        //UpdatedAt = DateTime.UtcNow;
        // TODO: Include the user who updated thee work item.

        return Result.Success();
    }

    public Result UpdateMethodology(ProjectMethodology methodology)
    {
        ProjectMethodology = methodology;
        return Result.Success();
    }

    public Result UpdateStatus(ProjectStatus status)
    {
        ProjectStatus = status;
        return Result.Success();
    }

    public Result UpdatePriority(ProjectPriority priority)
    {
        ProjectPriority = priority;
        return Result.Success();
    }

    public Result UpdateTimeRange(DateTime startTime, DateTime endTime)
    {
        ProjectTimeRange datetimes = ProjectTimeRange.Create(startTime, endTime);
        ProjectStartTime = datetimes.Start;
        ProjectEndTime = datetimes.End;
        return Result.Success();
    }
}