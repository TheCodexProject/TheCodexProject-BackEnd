using domain.models.project.values;
using domain.models.shared;
using domain.models.user;
using domain.models.workItem;
using domain.models.workItem.values;
using OperationResult;

namespace domain.models.project;

public class Project
{
    public Id<Project> Id { get; set; }

    public ProjectTitle ProjectTitle { get; private set; }

    public ProjectDescription? ProjectDescription { get; private set; }

    public ProjectTimeRange? ProjectTimeRange { get; private set; }

    public DateTime? ProjectStartTime => ProjectTimeRange.Start;

    public DateTime? ProjectEndTime => ProjectTimeRange.End;

    public ProjectMethodology? ProjectMethodology { get; private set; }

    public ProjectStatus? ProjectStatus { get; private set; }

    public ProjectPriority? ProjectPriority { get; private set; }

    private Project()
    {
        // "Specific" values
        Id = Id<Project>.Create();
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
        ProjectTimeRange = ProjectTimeRange.Create(startTime, endTime);
        return Result.Success();
    }
}