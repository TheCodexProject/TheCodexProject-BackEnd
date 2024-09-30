using domain.models.iteration.values;
using domain.models.shared;
using domain.models.workItem;
using OperationResult;
using System.Collections.ObjectModel;

namespace domain.models.iteration;

public class Iteration
{
    /// <summary>
    /// The unique identifier for the Iteration.
    /// </summary>
    public Id<Iteration> Id { get; private set; }

    // <summary>
    /// Holds the title of the Iteration.
    /// </summary>
    public IterationTitle? Title { get; private set; }

    /// <summary>
    /// Holds a IEnumerable of WorkItems.
    /// </summary>
    public ReadOnlyCollection<Id<WorkItem>> WorkItems => _workItems.AsReadOnly();
    private readonly List<Id<WorkItem>> _workItems;

    /// <summary>
    /// Creates a new instance of <see cref="Iteration"/> with default values.
    /// </summary>
    private Iteration()
    {
        Id = Id<Iteration>.Create();
        _workItems = new List<Id<WorkItem>>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Iteration"/> with default values.
    /// </summary>
    /// <returns>A <see cref="Iteration"/></returns>
    public static Iteration Create()
    {
        return new Iteration();
    }

    /// <summary>
    /// Updates the title of the IterationTitle.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateTitle(string title)
    {
        var newTitle = IterationTitle.Create(title);

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
    public void AddWorkItem(WorkItem workItem)
    {
        if (workItem == null)
        {
            throw new ArgumentNullException(nameof(workItem));
        }
        _workItems.Add(workItem.Id);
    }

    /// <summary>
    /// Removes a workitem from the list of workitems.
    /// </summary>
    /// <param name="workItem">The workitem to remove.</param>
    public Result RemoveWorkItem(WorkItem workItem)
    {
        if (workItem == null)
        {
            throw new ArgumentNullException(nameof(workItem));
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
