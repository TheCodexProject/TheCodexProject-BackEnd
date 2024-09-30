
using domain.exceptions.documentation.documentationTitle;
using domain.exceptions.project.ProjectTitle;
using domain.models.project.values;
using OperationResult;

namespace domain.models.documentation.values;

public class DocumentationTitle
{
    public string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private DocumentationTitle() { }

    /// <summary>
    /// The private constructor for the <see cref="DocumentationTitle"/> class.
    /// </summary>
    /// <param name="value"></param>
    private DocumentationTitle(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="DocumentationTitle"/> class.
    /// </summary>
    /// <param name="value">Title to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<DocumentationTitle> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<DocumentationTitle>.Failure(result.Errors.ToArray());
        }

        var documentationTitle = new DocumentationTitle(value);

        return documentationTitle;
    }

    /// <summary>
    /// Validates the documentation title.
    /// </summary>
    /// <param name="value">Title to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    public static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new DocumentationTitleEmptyException());
            return Result.Failure(errors.ToArray());
        }

        switch (value)
        {
            case { Length: < 3 }:
                errors.Add(new DocumentationTitleTooShortException());
                break;
            case { Length: > 75 }:
                errors.Add(new DocumentationTitleTooLongException());
                break;
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }
    /// <summary>
    /// Implicit conversion from <see cref="DocumentationTitle"/> to <see cref="string"/>
    /// </summary>
    /// <param name="documentationTitle">The title itself.</param>
    /// <returns>The inner value of the <see cref="DocumentationTitle"/> object.</returns>
    public static implicit operator string(DocumentationTitle documentationTitle) => documentationTitle.Value;

    /// <summary>
    /// Equality operator for the <see cref="DocumentationTitle"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is DocumentationTitle title)
        {
            return title.Value == Value;
        }

        return false;
    }
}