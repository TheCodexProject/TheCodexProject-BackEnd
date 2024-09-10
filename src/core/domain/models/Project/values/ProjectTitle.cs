using domain.exceptions.Project.ProjectTitle;
using domain.exceptions.WorkItem.WorkItemTitle;
using domain.models.workItem.values;
using OperationResult;

namespace domain.models.Project.values;

public class ProjectTitle
{
    private string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private ProjectTitle() { }

    /// <summary>
    /// The private constructor for the <see cref="ProjectTitle"/> class.
    /// </summary>
    /// <param name="value"></param>
    private ProjectTitle(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="ProjectTitle"/> class.
    /// </summary>
    /// <param name="value">Title to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<ProjectTitle> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<ProjectTitle>.Failure(result.Errors.ToArray());
        }

        var projectTitle = new ProjectTitle(value);

        return projectTitle;
    }

    /// <summary>
    /// Validates the project title.
    /// </summary>
    /// <param name="value">Title to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new ProjectTitleEmptyException());
            return Result.Failure(errors.ToArray());
        }

        switch (value)
        {
            case { Length: < 3 }:
                errors.Add(new ProjectTitleTooShortException());
                break;
            case { Length: > 75 }:
                errors.Add(new ProjectTitleTooLongException());
                break;
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Implicit conversion from <see cref="ProjectTitle"/> to <see cref="string"/>
    /// </summary>
    /// <param name="projectTitle">The title itself.</param>
    /// <returns>The inner value of the <see cref="WorkItemTitle"/> object.</returns>
    public static implicit operator string(ProjectTitle projectTitle) => projectTitle.Value;

    /// <summary>
    /// Equality operator for the <see cref="ProjectTitle"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is ProjectTitle title)
        {
            return title.Value == Value;
        }

        return false;
    }
}