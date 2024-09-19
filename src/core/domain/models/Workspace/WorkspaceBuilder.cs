using domain.exceptions;
using domain.exceptions.Workspace.WorkspaceTitle;
using OperationResult;

namespace domain.models.Workspace;

public class WorkspaceBuilder
{
    private readonly WorkspaceModel workspaceModel = WorkspaceModel.Create();
    private readonly List<Exception> _errors = new();


    /// <summary>
    /// The private constructor for the <see cref="WorkspaceBuilder"/> class.
    /// </summary>
    private WorkspaceBuilder() { }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="WorkspaceBuilder"/> class.
    /// </summary>
    /// <param name="value">Title to use.</param>
    /// <returns>A <see cref="WorkspaceBuilder"/></returns>
    public static WorkspaceBuilder Create()
    {
        return new WorkspaceBuilder();
    }

    /// <summary>
    /// Function to add title to the build of <see cref="WorkspaceBuilder"/>.
    /// </summary>
    /// <param name="value">Title to use.</param>
    public WorkspaceBuilder withTitle(string title)
    {
        var result = workspaceModel.UpdateTitle(title);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    /// <summary>
    /// Function to the build <see cref="WorkspaceBuilder"/>.
    /// </summary>
    public Result<WorkspaceModel> build() {

        // Required fields
        if (_errors.Any(e => e is WorkspaceTitleEmptyException)) {
            // * Take out the WorkspaceTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is WorkspaceTitleEmptyException);

            // * Remove the WorkspaceTitleEmptyException from the errors list.
            _errors.Remove(error);

            // * Create a new RequiredFieldMissingException with the WorkspaceTitleEmptyException as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
            _errors.Insert(0, requiredFieldMissingException);

        } else {
            if (workspaceModel.Title == null)
            {
                _errors.Add(new RequiredFieldMissingException("Title is required", new WorkspaceTitleEmptyException()));
            }
        }

        return _errors.Any() ? Result<WorkspaceModel>.Failure(_errors.ToArray()) : workspaceModel;
    }

    /// <summary>
    /// Function to the build with some default values <see cref="WorkspaceBuilder"/>.
    /// </summary>
    public Result<WorkspaceModel> buildWithDefaults()
    {
        return withTitle(WorkspaceConstants.DefaultTitle).build();
    }
}
