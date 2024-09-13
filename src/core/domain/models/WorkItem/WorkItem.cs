using domain.models.Users;
using domain.models.workItem.values;
using OperationResult;


namespace domain.models.workItem;

/// <summary>
/// The WorkItem class represents a single work item that can be created, updated, and assigned to a user.
/// </summary>
public class WorkItem
{
    #region Metadata
    
    /// <summary>
    /// The unique identifier for the WorkItem.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Holds the date and time when the WorkItem was created. (No modifiable)
    /// </summary>
    public DateTime CreatedAt { get; }
    /// <summary>
    /// Holds the user who created the WorkItem. (No modifiable)
    /// </summary>
    public string CreatedBy { get; }
    
    /// <summary>
    /// Holds the date and time when the WorkItem was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }
    
    /// <summary>
    /// Holds the user who last updated the WorkItem.
    /// </summary>
    public string? UpdatedBy { get; private set; }
    
    #endregion
    
    #region WorkItem properties

    /// <summary>
    /// Holds the title of the WorkItem.
    /// </summary>
    public WorkItemTitle Title { get; private set; }
    
    /// <summary>
    /// Holds the description of the WorkItem.
    /// </summary>
    public WorkItemDescription Description { get; private set; }
    
    /// <summary>
    /// Holds the status of the WorkItem.
    /// </summary>
    public WorkItemStatus Status { get; private set; }
    
    /// <summary>
    /// Holds the priority of the WorkItem.
    /// </summary>
    public WorkItemPriority Priority { get; private set; }
    
    /// <summary>
    /// Holds the type of the WorkItem.
    /// </summary>
    public WorkItemType Type { get; private set; }
    
    /// <summary>
    /// Holds the user who is assigned to the WorkItem.
    /// </summary>
    public User? Assignee { get; private set; }

    #endregion

    /// <summary>
    /// Constructs a new instance of <see cref="WorkItem"/> with a set of default values.
    /// </summary>
    private WorkItem()
    {
        // "Specific" values
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        
        // Default values
        Title = WorkItemConstants.DefaultTitle;
        Description = WorkItemConstants.DefaultDescription;
        Status = WorkItemConstants.DefaultStatus;
        Priority = WorkItemConstants.DefaultPriority;
        Type = WorkItemConstants.DefaultType;
    }


    /// <summary>
    /// Creates a new instance of <see cref="WorkItem"/> with default values.
    /// </summary>
    /// <returns></returns>
    public static WorkItem Create()
    {
        // ! No validation needed here
        // As the WorkItem can be modified through the provided methods.
        return new WorkItem();
    }
    
    /// <summary>
    /// Updates the title of the WorkItem.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateTitle(string title)
    {
        var newTitle = WorkItemTitle.Create(title);
        
        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the title?
        if (newTitle.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(newTitle.Errors.ToArray());
        }
        
        // Update the title.
        Title = newTitle.Value;
        
        // Update the updated at and updated by properties.
        UpdatedAt = DateTime.UtcNow;
        // TODO: Include the user who updated thee work item.
        
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the description of the WorkItem.
    /// </summary>
    /// <param name="description">The new description.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateDescription(string description)
    {
        var newDescription = WorkItemDescription.Create(description);
        
        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the description?
        if (newDescription.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(newDescription.Errors.ToArray());
        }
        
        // Update the description.
        Description = newDescription.Value;
        
        // Update the updated at and updated by properties.
        UpdatedAt = DateTime.UtcNow;
        // TODO: Include the user who updated thee work item.
        
        return Result.Success();
    }
    
    // NOTE: Should probably be exchanged for method to ensure that you can't set an invalid status.
    public Result UpdateStatus(WorkItemStatus status)
    {
        Status = status;
        return Result.Success();
    }
    
    // NOTE: Same as above.
    public Result UpdatePriority(WorkItemPriority priority)
    {
        Priority = priority;
        return Result.Success();
    }
    
    // NOTE: Should this be a method or just sub-class of WorkItem?
    public Result UpdateType(WorkItemType type)
    {
        Type = type;
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the assignee of the WorkItem.
    /// </summary>
    /// <param name="assignee">The new assignee</param>
    /// <returns></returns>
    public Result UpdateAssignee(User assignee)
    {
        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the assignee?
        
        // Update the assignee.
        Assignee = assignee;
        
        // Update the updated at and updated by properties.
        UpdatedAt = DateTime.UtcNow;
        // TODO: Include the user who updated thee work item.
        
        return Result.Success();
    }
    

    
    
    
    
    
    
}