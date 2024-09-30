using domain.exceptions;
using domain.exceptions.workspace;
using domain.exceptions.Workspace.WorkspaceTitle;
using domain.interfaces;
using domain.models.Interfaces;
using domain.models.project;
using domain.models.user;
using OperationResult;

namespace domain.models.workspace;

public class WorkspaceBuilder : IBuilder<Workspace>
{
    private readonly Workspace _workspace = Workspace.Create();
    private readonly List<Exception> _errors = new();

    /// <summary>
    /// The private constructor for the <see cref="WorkspaceBuilder"/> class.
    /// </summary>
    private WorkspaceBuilder() { }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="WorkspaceBuilder"/> class.
    /// </summary>
    /// <returns>A <see cref="WorkspaceBuilder"/></returns>
    public static WorkspaceBuilder Create()
    {
        return new WorkspaceBuilder();
    }

    /// <summary>
    /// Function to add title to the build of <see cref="WorkspaceBuilder"/>.
    /// </summary>
    /// <param name="title">Title to use.</param>
    public WorkspaceBuilder WithTitle(string title)
    {
        var result = _workspace.UpdateTitle(title);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    /// <summary>
    /// Function to add owner to the build of <see cref="WorkspaceBuilder"/>.
    /// </summary>
    /// <param name="owner">Owner to use.</param>
    /// <returns></returns>
    public WorkspaceBuilder WithOwner(IOwnership owner)
    {
        var result = _workspace.UpdateOwner(owner);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    /// <summary>
    /// Function to add projects to the build of <see cref="WorkspaceBuilder"/>.
    /// </summary>
    /// <param name="projects">Projects to add.</param>
    public WorkspaceBuilder WithProjects(List<Project> projects)
    {
        foreach (var project in projects)
        {
            var result = _workspace.AddProject(project);
            if (result.IsFailure)
            {
                _errors.AddRange(result.Errors);
            }
        }

        return this;
    }

    /// <summary>
    /// Function to add contacts to the build of <see cref="WorkspaceBuilder"/>.
    /// </summary>
    /// <param name="contacts">Contacts to add.</param>
    public WorkspaceBuilder WithContacts(List<User> contacts)
    {
        foreach (var contact in contacts)
        {
            var result = _workspace.AddContact(contact);
            if (result.IsFailure)
            {
                _errors.AddRange(result.Errors);
            }
        }

        return this;
    }

    /// <summary>
    /// Function to the build <see cref="WorkspaceBuilder"/>.
    /// </summary>
    public Result<Workspace> Build()
    {
        // Required fields
        if (_errors.Any(e => e is WorkspaceTitleEmptyException))
        {
            // * Take out the WorkspaceTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is WorkspaceTitleEmptyException);

            // * Remove the WorkspaceTitleEmptyException from the errors list.
            _errors.Remove(error);

            // * Create a new RequiredFieldMissingException with the WorkspaceTitleEmptyException as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
            _errors.Insert(0, requiredFieldMissingException);
        }
        else
        {
            if (_workspace.Title == null)
            {
                _errors.Add(new RequiredFieldMissingException("Title is required", new WorkspaceTitleEmptyException()));
            }
        }

        if (_workspace.Owner == null)
        {
            _errors.Add(new RequiredFieldMissingException("Owner is required", new WorkspaceOwnerEmptyException()));
        }

        return _errors.Any() ? Result<Workspace>.Failure(_errors.ToArray()) : _workspace;
    }

    /// <summary>
    /// Function to the build with some default values <see cref="WorkspaceBuilder"/>.
    /// </summary>
    public Result<Workspace> MakeDefault()
    {
        return new WorkspaceBuilder().WithTitle(WorkspaceConstants.DefaultTitle).WithOwner(WorkspaceConstants.DefaultOwner).Build();
    }
}
