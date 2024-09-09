using domain.exceptions.Workspace.WorkspaceTitle;
using OperationResult;

namespace domain.models.Workspace.values;

internal class WorkspaceTitle
{
    private string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private WorkspaceTitle() { }

    /// <summary>
    /// The private constructor for the <see cref="WorkspaceTitle"/> class.
    /// </summary>
    /// <param name="value"></param>
    private WorkspaceTitle(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="WorkspaceTitle"/> class.
    /// </summary>
    /// <param name="value">Title to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<WorkspaceTitle> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<WorkspaceTitle>.Failure(result.Errors.ToArray());
        }

        var workspaceTitle = new WorkspaceTitle(value);

        return workspaceTitle;
    }

    /// <summary>
    /// Validates the work item title.
    /// </summary>
    /// <param name="value">Title to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new WorkspaceTitleEmptyException());
            return Result.Failure(errors.ToArray());
        }

        switch (value)
        {
            case { Length: < 3 }:
                errors.Add(new WorkspaceTitleTooShortException());
                break;
            case { Length: >= 10 }:
                errors.Add(new WorkspaceTitleTooLongException());
                break;
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Implicit conversion from <see cref="WorkspaceTitle"/> to <see cref="string"/>
    /// </summary>
    /// <param name="workspaceTitle">The title itself.</param>
    /// <returns>The inner value of the <see cref="WorkspaceTitle"/> object.</returns>
    public static implicit operator string(WorkspaceTitle workspaceTitle) => workspaceTitle.Value;

    /// <summary>
    /// Equality operator for the <see cref="WorkspaceTitle"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is WorkspaceTitle title)
        {
            return title.Value == Value;
        }

        return false;
    }





}
