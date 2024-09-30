using System.Collections.ObjectModel;
using domain.exceptions.WorkItem;
using domain.models.shared;
using domain.models.user;
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
    
    // TODO: Add the list of documentation to the WorkItem.
    // public List<Documentation> Documentations { get; private set; }
    
    /// <summary>
    /// A list of sub items that are related to the WorkItem.
    /// </summary>
    private List<WorkItem> _subItems { get; }
    
    /// <summary>
    /// Returns a read-only list of the sub items.
    /// </summary>
    public ReadOnlyCollection<WorkItem> SubItems => _subItems.AsReadOnly();
    
    /// <summary>
    /// A list of tasks needed to be completed before the WorkItem can be started.
    /// </summary>
    private List<Id<WorkItem>> _dependencies { get; }
    
    /// <summary>
    /// Returns a read-only list of the dependencies.
    /// </summary>
    public ReadOnlyCollection<Id<WorkItem>> Dependencies => _dependencies.AsReadOnly();
    
    /// <summary>
    /// Constructs a new instance of <see cref="WorkItem"/> with a set of default values.
    /// </summary>
    private WorkItem() 
    {
        // "Specific" values
        Id = Id<WorkItem>.Create();
        _subItems = new List<WorkItem>();
        _dependencies = new List<Id<WorkItem>>();
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
            workItem.InitializeMetadata(createdBy);
        }
        
        return workItem;
    }

    /// <summary>
    /// Updates the title of the WorkItem.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <param name="modifiedBy">The user who updated this.</param>
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
        if (modifiedBy != null && Metadata != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the description of the WorkItem.
    /// </summary>
    /// <param name="description">The new description.</param>
    /// <param name="modifiedBy">The user who updated this.</param>
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
        if (modifiedBy != null && Metadata != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        
        return Result.Success();
    }

    /// <summary>
    /// Updates the status of the WorkItem.
    /// </summary>
    /// <param name="status">The new status.</param>
    /// <param name="modifiedBy">The user who updated this.</param>
    /// <returns></returns>
    public Result UpdateStatus(WorkItemStatus status, User? modifiedBy = null)
    {
        Status = status;
        if (modifiedBy != null && Metadata != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the priority of the WorkItem.
    /// </summary>
    /// <param name="priority">The new priority.</param>
    /// <param name="modifiedBy">The user who updated this.</param>
    /// <returns></returns>
    public Result UpdatePriority(WorkItemPriority priority, User? modifiedBy = null)
    {
        Priority = priority;
        if (modifiedBy != null && Metadata != null)
        {
            Metadata.Update(modifiedBy.Email);
        }
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the type of the WorkItem.
    /// </summary>
    /// <param name="type">The new type.</param>
    /// <param name="modifiedBy">The user who updated this.</param>
    /// <returns></returns>
    public Result UpdateType(WorkItemType type, User? modifiedBy = null)
    {
        // Update the type.
        Type = type;

        // Update the updated at and updated by properties.
        if (modifiedBy != null && Metadata != null)
        {
            Metadata.Update(modifiedBy.Email);
        }

        return Result.Success();
    }
    
    /// <summary>
    /// Updates the assignee of the WorkItem.
    /// </summary>
    /// <param name="assignee">The new assignee.</param>
    /// <param name="modifiedBy">The user who updated this.</param>
    /// <returns></returns>
    public Result UpdateAssignee(User assignee, User? modifiedBy = null)
    {
        // Update the assignee.
        Assignee = assignee;
        
        // Update the updated at and updated by properties.
        if (modifiedBy != null && Metadata != null)
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
    public Result InitializeMetadata(User? createdBy)
    {
        // ! VALIDATION

        // ? Check if the metadata is already initialized.
        if (Metadata != null)
        {
            // ! Returns an error if the metadata is already initialized.
            return Result.Failure(new MetadataAlreadyInitializedException());
        }

        // ? Check if the user is null.
        if (createdBy is null)
        {
            // ! Returns an error if the user is null.
            return Result.Failure(new UserNotFoundException());
        }

        // Initialize the metadata.
        Metadata = Metadata.Create(createdBy.Email);
        return Result.Success();
    }

    /// <summary>
    /// Adds a sub item to the WorkItem.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <returns></returns>
    public Result AddSubItem(WorkItem? item)
    {
        // ! VALIDATION
        // ? Check if the item is null.
        if (item is null)
        {
            // ! Returns an error if the sub item is null.
            return Result.Failure(new SubItemNotFoundException("The given sub item is null."));
        }

        // ? Check if the item already exists in the list.
        if (_subItems.Contains(item))
        {
            // ! Returns an error if the sub item already exists.
            return Result.Failure(new SubItemAlreadyExistsException());
        }
        
        // Add the sub item.
        _subItems.Add(item);
        
        return Result.Success();
    }

    /// <summary>
    /// Adds a dependency to the WorkItem.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <returns></returns>
    public Result AddDependency(Id<WorkItem>? item)
    {
        // ! VALIDATION

        // ? Check if the item is null.
        if (item is null)
        {
            // ! Returns an error if the dependency is null.
            return Result.Failure(new DependencyNotFoundException("The given dependency is null."));
        }

        // ? Check if the item already exists in the list.
        if (_dependencies.Contains(item))
        {
            // ! Returns an error if the dependency already exists.
            return Result.Failure(new DependencyAlreadyExistsException());
        }

        // Add the dependency.
        _dependencies.Add(item);
        
        return Result.Success();
    }

    /// <summary>
    /// Removes a sub item from the WorkItem.
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    /// <returns></returns>
    public Result RemoveSubItem(WorkItem? item)
    {
        // ! VALIDATION

        // ? Check if the item is null.
        if (item is null)
        {
            return Result.Failure(new SubItemNotFoundException("The given sub item is null."));
        }
                
        // ? Look if the item exists in the list.
        if (!_subItems.Contains(item))
        {
            return Result.Failure(new SubItemNotFoundException());
        }
        
        // Remove the sub item.
        _subItems.Remove(item);
        
        return Result.Success();
    }

    /// <summary>
    /// Removes a dependency from the WorkItem.
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    /// <returns></returns>
    public Result RemoveDependency(Id<WorkItem>? item)
    {
        // ! VALIDATION

        // ? Check if the item is null.
        if (item is null)
        {
            return Result.Failure(new DependencyNotFoundException("The given dependency is null."));
        }


        // ? Look if the item exists in the list.
        if (!_dependencies.Contains(item))
        {
            return Result.Failure(new DependencyNotFoundException());
        }
        
        // Remove the dependency.
        _dependencies.Remove(item);
        
        return Result.Success();
    }
}