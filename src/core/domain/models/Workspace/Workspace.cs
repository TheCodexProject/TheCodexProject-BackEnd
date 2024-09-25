
using domain.models.Interfaces;
using domain.models.shared;
using domain.models.workspace.values;
using OperationResult;
using domain.models.project;
using domain.models.user;

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
    /// Holds a IEnumerable of projects.
    /// </summary>
    public IEnumerable<Project> Projects => _projects;
    private readonly List<Project> _projects;

    /// <summary>
    /// Holds a IEnumerable of Contacts/User.
    /// </summary>
    public IEnumerable<User> Contacts => _contacts;
    private readonly List<User> _contacts;

    // TODO
    /// <summary>
    /// Holds a IEnumerable of Documents.
    /// </summary>
    //public IEnumerable<User> Documents => _documents;
    //private readonly List<User> _documents;

    /// <summary>
    /// Creates a new instance of <see cref="Workspace"/> with default values.
    /// </summary>
    private Workspace()
    {
        Id = Id<Workspace>.Create();
        _projects = new List<Project>();
        _contacts = new List<User>();
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
    /// Adds a project to the list of projects.
    /// </summary>
    /// <param name="project">The project to add.</param>
    public void AddProject(Project project)
    {
        if (project == null)
        {
            throw new ArgumentNullException(nameof(project));
        }
        _projects.Add(project);
    }

    /// <summary>
    /// Removes a project from the list of projects.
    /// </summary>
    /// <param name="project">The project to remove.</param>
    public Result RemoveProject(Project project)
    {
        var existingProject = _projects.FirstOrDefault(p => p.Equals(project));

        if (existingProject == null)
        {
            // Project not found, return failure.
            return Result.Failure();
        }

        _projects.Remove(existingProject);
        return Result.Success();
    }

    /// <summary>
    /// Adds a contact to the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to add.</param>
    public void AddContact(User contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }
        _contacts.Add(contact);
    }

    /// <summary>
    /// Removes a contact from the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to remove.</param>
    public Result RemoveContact(User contact)
    {
        var existingContact = _contacts.FirstOrDefault(c => c.Equals(contact));

        if (existingContact == null)
        {
            // Contact not found, return failure.
            return Result.Failure();
        }

        _contacts.Remove(existingContact);
        return Result.Success();
    }
}

