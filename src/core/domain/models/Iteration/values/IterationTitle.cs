
using domain.exceptions.iteration.iterationTitle;
using domain.models.workspace.values;
using OperationResult;

namespace domain.models.iteration.values;

public class IterationTitle
{
    public string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private IterationTitle() { }

    /// <summary>
    /// The private constructor for the <see cref="IterationTitle"/> class.
    /// </summary>
    /// <param name="value"></param>
    private IterationTitle(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="IterationTitle"/> class.
    /// </summary>
    /// <param name="value">Title to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<IterationTitle> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<IterationTitle>.Failure(result.Errors.ToArray());
        }

        var iterationTitle = new IterationTitle(value);

        return iterationTitle;
    }

    /// <summary>
    /// Validates the iteration title.
    /// </summary>
    /// <param name="value">Title to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new IterationTitleEmptyException());
            return Result.Failure(errors.ToArray());
        }

        switch (value)
        {
            case { Length: < 3 }:
                errors.Add(new IterationTitleTooShortException());
                break;
            case { Length: >= 75 }:
                errors.Add(new IterationTitleTooLongException());
                break;
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Implicit conversion from <see cref="IterationTitle"/> to <see cref="string"/>
    /// </summary>
    /// <param name="workspaceTitle">The title itself.</param>
    /// <returns>The inner value of the <see cref="WorkspaceTitle"/> object.</returns>
    public static implicit operator string(IterationTitle iterationTitle) => iterationTitle.Value;

    /// <summary>
    /// Equality operator for the <see cref="IterationTitle"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is IterationTitle title)
        {
            return title.Value == Value;
        }

        return false;
    }
}
