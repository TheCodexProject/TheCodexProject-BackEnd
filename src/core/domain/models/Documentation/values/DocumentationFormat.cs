using domain.exceptions.documentation.documentationFormat;
using OperationResult;

namespace domain.models.Documentation.values;
public class DocumentationFormat
{
    public string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private DocumentationFormat() { }

    /// <summary>
    /// The private constructor for the <see cref="DocumentationFormat"/> class.
    /// </summary>
    /// <param name="value"></param>
    private DocumentationFormat(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="DocumentationFormat"/> class.
    /// </summary>
    /// <param name="value">Format to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<DocumentationFormat> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<DocumentationFormat>.Failure(result.Errors.ToArray());
        }

        var documentationFormat = new DocumentationFormat(value);

        return documentationFormat;
    }

    /// <summary>
    /// Validates the documentation format.
    /// </summary>
    /// <param name="value">Format to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    public static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new DocumentationFormatEmptyException());
            return Result.Failure(errors.ToArray());
        }

        switch (value)
        {
            case { Length: > 5 }:
                errors.Add(new DocumentationFormatTooLongException());
                break;
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Implicit conversion from <see cref="DocumentationFormat"/> to <see cref="string"/>
    /// </summary>
    /// <param name="documentationFormat">The format itself.</param>
    /// <returns>The inner value of the <see cref="DocumentationFormat"/> object.</returns>
    public static implicit operator string(DocumentationFormat documentationFormat) => documentationFormat.Value;

    public override bool Equals(object? obj)
    {
        if (obj is DocumentationFormat format)
        {
            return format.Value == Value;
        }

        return false;
    }
}