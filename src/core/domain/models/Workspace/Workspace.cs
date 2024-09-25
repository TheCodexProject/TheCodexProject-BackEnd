
using domain.models.Interfaces;
using domain.models.shared;
using domain.models.workspace.values;
using OperationResult;

namespace domain.models.workspace;
public class Workspace
{
    /// <summary>
    /// The unique identifier for the WorkItem.
    /// </summary>
    public Id<Workspace> Id { get; private set; }

    /// <summary>
    /// Holds the title of the Workspace.
    /// </summary>
    public WorkspaceTitle? Title { get; private set; }

    /// <summary>
    /// Holds a list of resources, this cloud be a projekts or documents.
    /// </summary>
    public List<IResource> Resources { get; private set; }
    
    /// <summary>
    /// This allows for either a User or Organisation to be the owner of the Workspace.
    /// </summary>
    public IOwnership Owner { get; private set; }

    /// <summary>
    /// Creates a new instance of <see cref="Workspace"/> with default values.
    /// </summary>
    private Workspace()
    {
        Id = Id<Workspace>.Create();
        Resources = new List<IResource>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Workspace"/> with default values.
    /// </summary>
    /// <returns>A <see cref="Workspace"/></returns>
    public static Workspace Create()
    {
        return new Workspace();
    }

    /// <summary>
    /// Updates the title of the WorkItem.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateTitle(string title)
    {
        var newTitle = WorkspaceTitle.Create(title);

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
    /// Adds a resource to resources
    /// </summary>
    /// <param name="resource">The resource to add.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result AddResource(IResource resource)
    {
        Resources.Add(resource);
        return Result.Success();
    }

    /// <summary>
    /// Removes a resource from resources
    /// </summary>
    /// <param name="resource">The resource to remove.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result RemoveResource(IResource resource)
    {
        var existingResource = Resources.FirstOrDefault(r => r.Equals(resource));

        if (existingResource == null)
        {
            // Resource not found, return failure.
            return Result.Failure();
        }

        Resources.Remove(existingResource);
        return Result.Success();
    }
    
    // TODO: Make a method that allows for the owner to be updated.
    // public Result SetOwner(IOwnership owner) ?
    // Public Result TransferOwnership(IOwnership newOwner) ?
}

