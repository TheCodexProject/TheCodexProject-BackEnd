using domain.models.Interfaces;
using domain.models.shared;
using domain.models.workspace.values;
using OperationResult;
using domain.models.project;
using domain.models.user;
using System.Collections.ObjectModel;
using domain.exceptions.workspace;
using domain.models.documentation;

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
    /// This allows for either a User or Organisation to be the owner of the Workspace.
    /// </summary>
    public IOwnership Owner { get; private set; }

    /// <summary>
    /// Holds a private list of projects.
    /// </summary>
    private readonly List<Project> _projects = new List<Project>();

    /// <summary>
    /// Holds a private list of contacts/users.
    /// </summary>
    private readonly List<User> _contacts = new List<User>();

    /// <summary>
    /// Holds a private list of documents.
    /// </summary>
    private readonly List<Documentation> _documents = new List<Documentation>();

    /// <summary>
    /// Exposes a read-only view of projects.
    /// </summary>
    public ReadOnlyCollection<Project> Projects => _projects.AsReadOnly();

    /// <summary>
    /// Exposes a read-only view of contacts/users.
    /// </summary>
    public ReadOnlyCollection<User> Contacts => _contacts.AsReadOnly();

    /// <summary>
    /// Exposes a read-only view of documents.
    /// </summary>
    public ReadOnlyCollection<Documentation> Documents => _documents.AsReadOnly();

    /// <summary>
    /// Creates a new instance of <see cref="Workspace"/> with default values.
    /// </summary>
    private Workspace()
    {
        Id = Id<Workspace>.Create();
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
    /// Updates the title of the Workspace.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateTitle(string title)
    {
        var newTitle = WorkspaceTitle.Create(title);

        if (newTitle.IsFailure)
        {
            return Result.Failure(newTitle.Errors.ToArray());
        }

        Title = newTitle.Value;
        return Result.Success();
    }

    /// <summary>
    /// Adds a project to the list of projects.
    /// </summary>
    /// <param name="project">The project to add.</param>
    public Result AddProject(Project project)
    {
        if (project == null)
        {
            return Result.Failure(new WorkspaceProjectNotFoundException("The given project is null"));
        }

        if (_projects.Contains(project))
        {
            return Result.Failure(new WorkspaceProjectAlreadyExistsException());
        }

        _projects.Add(project);
        return Result.Success();
    }

    /// <summary>
    /// Removes a project from the list of projects.
    /// </summary>
    /// <param name="project">The project to remove.</param>
    public Result RemoveProject(Project project)
    {
        if (!_projects.Contains(project))
        {
            return Result.Failure(new WorkspaceProjectNotFoundException());
        }

        _projects.Remove(project);
        return Result.Success();
    }

    /// <summary>
    /// Adds a contact to the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to add.</param>
    public Result AddContact(User contact)
    {
        if (contact == null)
        {
            return Result.Failure(new WorkspaceContactNotFoundException("The given contact is null"));
        }

        if (_contacts.Contains(contact))
        {
            return Result.Failure(new WorkspaceContactAlreadyExistsException());
        }

        _contacts.Add(contact);
        return Result.Success();
    }

    /// <summary>
    /// Removes a contact from the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to remove.</param>
    public Result RemoveContact(User contact)
    {
        if (!_contacts.Contains(contact))
        {
            return Result.Failure(new WorkspaceContactNotFoundException());
        }

        _contacts.Remove(contact);
        return Result.Success();
    }

    /// <summary>
    /// Updates the owner of the Workspace.
    /// </summary>
    /// <param name="owner">The new owner.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateOwner(IOwnership owner)
    {
        if (owner == null)
        {
            return Result.Failure(new WorkspaceOwnerNotFoundException("The given owner is null")); 
        }

        Owner = owner;
        return Result.Success();
    }
}
