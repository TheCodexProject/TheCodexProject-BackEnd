using System.Dynamic;
using domain.models.shared;
using domain.models.Users;
using domain.models.workItem.values;
using OperationResult;


namespace domain.models.workItem;

/// <summary>
/// The WorkItem class represents a single work item that can be created, updated, and assigned to a user.
/// </summary>
public class WorkItem
{

    /// <summary>
    /// The unique identifier for the WorkItem.
    /// </summary>
    public Id<WorkItem> Id { get; private set; }
    
    /// <summary>
    /// Holds the metadata for the work item, not modifiable.
    /// </summary>
    public Metadata? Metadata { get; private set; }
    
    /// <summary>
    /// Holds the title of the WorkItem.
    /// </summary>
    public WorkItemTitle? Title { get; private set; }
    
    /// <summary>
    /// Holds the description of the WorkItem.
    /// </summary>
    public WorkItemDescription? Description { get; private set; }
    
    /// <summary>
    /// Holds the status of the WorkItem.
    /// </summary>
    public WorkItemStatus? Status { get; private set; }
    
    /// <summary>
    /// Holds the priority of the WorkItem.
    /// </summary>
    public WorkItemPriority? Priority { get; private set; }
    
    /// <summary>
    /// Holds the type of the WorkItem.
    /// </summary>
    public WorkItemType? Type { get; private set; }
    
    /// <summary>
    /// Holds the user who is assigned to the WorkItem.
    /// </summary>
    public User? Assignee { get; private set; }
    
    /// <summary>
    /// Constructs a new instance of <see cref="WorkItem"/> with a set of default values.
    /// </summary>
    private WorkItem() 
    {
        // "Specific" values
        Id = Id<WorkItem>.Create();
    }
    
    /// <summary>
    /// Creates a instance of <see cref="WorkItem"/> with an optional user who created the WorkItem.
    /// </summary>
    /// <param name="createdBy">Who created the item.</param>
    /// <returns></returns>
    public static WorkItem Create(User? createdBy = null)
    {
        // ! No validation needed here
        // As the WorkItem can be modified through the provided methods.
        var workItem = new WorkItem();
        
        // If a user is provided, create the metadata. Else, the metadata will be null.
        if(createdBy != null)
        {
            workItem.Metadata = Metadata.Create(createdBy.Email);
        }
        
        return workItem;
    }

    /// <summary>
    /// Updates the title of the WorkItem.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateTitle(string title, User? modifiedBy = null)
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
        if (modifiedBy != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the description of the WorkItem.
    /// </summary>
    /// <param name="description">The new description.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateDescription(string description, User? modifiedBy = null)
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
        if (modifiedBy != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        
        return Result.Success();
    }
    
    // NOTE: Should probably be exchanged for method to ensure that you can't set an invalid status.
    public Result UpdateStatus(WorkItemStatus status, User? modifiedBy = null)
    {
        Status = status;
        if (modifiedBy != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        return Result.Success();
    }
    
    // NOTE: Same as above.
    public Result UpdatePriority(WorkItemPriority priority, User? modifiedBy = null)
    {
        Priority = priority;
        if (modifiedBy != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        return Result.Success();
    }
    
    // NOTE: Same as above.
    public Result UpdateType(WorkItemType type, User? modifiedBy = null)
    {
        Type = type;
        if (modifiedBy != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the assignee of the WorkItem.
    /// </summary>
    /// <param name="assignee">The new assignee</param>
    /// <returns></returns>
    public Result UpdateAssignee(User assignee, User? modifiedBy = null)
    {
        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the assignee?
        
        // Update the assignee.
        Assignee = assignee;
        
        // Update the updated at and updated by properties.
        if (modifiedBy != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        
        return Result.Success();
    }
    
    /// <summary>
    /// WIP: Initializes the metadata for the WorkItem.
    /// </summary>
    /// <param name="createdBy">Who created the item.</param>
    /// <returns></returns>
    public Result InitializeMetadata(User createdBy)
    {
        Metadata = Metadata.Create(createdBy.Email);
        return Result.Success();
    }
}