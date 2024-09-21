using domain.exceptions;
using domain.exceptions.WorkItem.WorkItemTitle;
using domain.interfaces;
using domain.models.user;
using domain.models.workItem.values;
using OperationResult;

namespace domain.models.workItem;

/// <summary>
/// A builder class for the <see cref="WorkItem"/> class.
/// </summary>
public class WorkItemBuilder : IBuilder<WorkItem>
{
    /// <summary>
    /// The work item to be built.
    /// </summary>
    private readonly WorkItem _workItem = WorkItem.Create();
    private readonly List<Exception> _errors = new();
    
    public static WorkItemBuilder Create()
    {
        return new WorkItemBuilder();
    }

    public Result<WorkItem> MakeDefault()
    {
        return new WorkItemBuilder()
            .WithTitle(WorkItemConstants.Title)
            .WithDescription(WorkItemConstants.Description)
            .WithStatus(WorkItemConstants.Status)
            .WithPriority(WorkItemConstants.Priority)
            .WithType(WorkItemConstants.Type)
            .Build();
    }
    
    /// <summary>
    /// Sets the title of the work item.
    /// </summary>
    /// <param name="title">The title to be set.</param>
    /// <returns></returns>
    public WorkItemBuilder WithTitle(string title)
    {
        var result = _workItem.UpdateTitle(title);
        
        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }
        
        return this;
    }
    
    /// <summary>
    /// Sets the description of the work item.
    /// </summary>
    /// <param name="description">The description to be set.</param>
    /// <returns></returns>
    public WorkItemBuilder WithDescription(string description)
    {
        var result = _workItem.UpdateDescription(description);
        
        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }
        
        return this;
    }
    
    /// <summary>
    /// Sets the status of the work item.
    /// </summary>
    /// <param name="status">The status to be set.</param>
    /// <returns></returns>
    public WorkItemBuilder WithStatus(WorkItemStatus status)
    {
        var result = _workItem.UpdateStatus(status);
        
        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }
    
    /// <summary>
    /// Sets the priority of the work item.
    /// </summary>
    /// <param name="priority">The priority to be set.</param>
    /// <returns></returns>
    public WorkItemBuilder WithPriority(WorkItemPriority priority)
    {
        var result = _workItem.UpdatePriority(priority);
        
        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }
    
    /// <summary>
    /// Sets the type of the work item.
    /// </summary>
    /// <param name="type">The type to be set.</param>
    /// <returns></returns>
    public WorkItemBuilder WithType(WorkItemType type)
    {
        var result = _workItem.UpdateType(type);
        
        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }
    
    /// <summary>
    /// Sets the assignee of the work item.
    /// </summary>
    /// <param name="assignee">The assigne to be set.</param>
    /// <returns></returns>
    public WorkItemBuilder WithAssignee(User assignee)
    {
        var result = _workItem.UpdateAssignee(assignee);
        
        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }
    
    /// <summary>
    /// Adds a creator to the work item, which initializes the metadata.
    /// </summary>
    /// <param name="createdBy">Who created the item.</param>
    /// <returns></returns>
    public WorkItemBuilder WithMetadata(User createdBy)
    {
        var result = _workItem.InitializeMetadata(createdBy);
        
        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }
    
    public Result<WorkItem> Build()
    {
        // ? Check if there are any WorkItemTitleEmptyExceptions in the errors list.
        if (_errors.Any(e => e is WorkItemTitleEmptyException))
        {
            // * Take out the WorkItemTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is WorkItemTitleEmptyException);
            
            // * Remove the WorkItemTitleEmptyException from the errors list.
            _errors.Remove(error);
            
            // * Create a new RequiredFieldMissingException with the WorkItemTitleEmptyException as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.",error);
            _errors.Insert(0,requiredFieldMissingException);
        }
        else
        {
            if(_workItem.Title == null)
            {
                _errors.Add(new RequiredFieldMissingException("Title is required.",new WorkItemTitleEmptyException()));
            }
        }
        
        // ? Check if there are any errors in the errors list.
        return _errors.Any() ? Result<WorkItem>.Failure(_errors.ToArray()) : _workItem;
    }

    
}