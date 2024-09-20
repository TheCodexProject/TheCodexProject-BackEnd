using domain.exceptions.project.ProjectDescription;
using OperationResult;

namespace domain.models.project.values;

public class ProjectDescription
{
    private string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private ProjectDescription() { }

    private ProjectDescription(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="ProjectDescription"/> class.
    /// </summary>
    /// <param name="value">Description to use</param>
    /// <returns> A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<ProjectDescription> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<ProjectDescription>.Failure(result.Errors.ToArray());
        }

        var ProjectDescription = new ProjectDescription(value);

        return ProjectDescription;
    }

    /// <summary>
    /// Validates the project description.
    /// </summary>
    /// <param name="value">Description to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (value.Length > 500)
        {
            errors.Add(new ProjectDescriptionTooLongException());
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Implicitly converts a <see cref="ProjectDescription"/> to a <see cref="string"/>.
    /// </summary>
    /// <param name="description">The description itself.</param>
    /// <returns>The inner value of the <see cref="ProjectDescription"/> object.</returns>
    public static implicit operator string(ProjectDescription description) => description.Value;

    /// <summary>
    /// Equality operator for the <see cref="ProjectDescription"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is ProjectDescription description)
        {
            return description.Value == Value;
        }

        return false;
    }
}