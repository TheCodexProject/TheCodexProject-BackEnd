
using domain.models.Interfaces;
using domain.models.Workspace.values;
using OperationResult;

namespace domain.models.Workspace;
public class Workspace
{

    #region properties

    /// <summary>
    /// The unique identifier for the WorkItem.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Holds the title of the Workspace.
    /// </summary>
    public WorkspaceTitle? Title { get; private set; }

    /// <summary>
    /// Holds a list of resources.
    /// </summary>
    public List<IResource> Resources { get; private set; }

    #endregion

    #region constructors

    /// <summary>
    /// Creates a new instance of <see cref="Workspace"/> with default values.
    /// </summary>
    private Workspace()
    {
        Id = Guid.NewGuid();
        Resources = new List<IResource>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="WorkItem"/> with default values.
    /// </summary>
    /// <returns>A <see cref="Workspace"/></returns>
    public static Workspace Create()
    {
        return new Workspace();
    }

    #endregion

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
        var test = Resources.Remove(resource);
        
        if (!test)
        {
            return Result.Failure();
        }

        return Result.Success();
    }
}

