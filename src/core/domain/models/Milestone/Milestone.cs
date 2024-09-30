using domain.exceptions.milestone;
using domain.models.milestone.values;
using domain.models.shared;
using domain.models.workItem;
using OperationResult;

namespace domain.models.milestone;

public class Milestone
{
    public Id<Milestone> Id { get; private set; }

    public MilestoneTitle Title { get; private set; }

    public List<Id<WorkItem>> WorkItems => _workItems;

    private readonly List<Id<WorkItem>> _workItems;

    private Milestone()
    {
        Id = Id<Milestone>.Create();
        _workItems = new List<Id<WorkItem>>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Milestone"/> with default values.
    /// </summary>
    /// <returns>A <see cref="Milestone"/></returns>
    public static Milestone Create()
    {
        return new Milestone();
    }

    /// <summary>
    /// Updates the title of the MilestoneTitle.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateTitle(string title)
    {
        var newTitle = MilestoneTitle.Create(title);

        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the title?
        if (newTitle.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(newTitle.Errors.ToArray());
        }

        // Update the title.
        Title = newTitle.Value;

        return Result.Success();
    }

    /// <summary>
    /// Adds a workitem to the list of workitems.
    /// </summary>
    /// <param name="workItem">The workitem to add.</param>
    public Result AddWorkItem(WorkItem workItem)
    {
        if (workItem == null)
        {
            return Result.Failure(new MilestoneWorkItemErrorException());
        }
        _workItems.Add(workItem.Id);

        return Result.Success();
    }

    /// <summary>
    /// Removes a workitem from the list of workitems.
    /// </summary>
    /// <param name="workItem">The workitem to remove.</param>
    public Result RemoveWorkItem(WorkItem workItem)
    {
        if (workItem == null)
        {
            return Result.Failure(new MilestoneWorkItemErrorException());
        }

        var existingWorkItem = _workItems.FirstOrDefault(wi => wi.Equals(workItem.Id));

        if (existingWorkItem == null)
        {
            // WorkItem not found, return failure.
            return Result.Failure();
        }

        _workItems.Remove(existingWorkItem);
        return Result.Success();
    }
}