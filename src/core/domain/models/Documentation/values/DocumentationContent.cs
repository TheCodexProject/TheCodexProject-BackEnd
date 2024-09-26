using domain.exceptions.documentation.documentationContent;
using domain.models.documentation.values;
using OperationResult;
using System.Net.Http.Headers;

namespace domain.models.documentation.values;

public class DocumentationContent
{
    public string Value { get; }

    private DocumentationContent() { }

    private DocumentationContent(string value)
    {
        Value = value;
    }

    public static Result<DocumentationContent> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<DocumentationContent>.Failure(result.Errors.ToArray());
        }

        var documentationContent = new DocumentationContent(value);

        return documentationContent;
    }

    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new DocumentationContentEmptyException());
            return Result.Failure(errors.ToArray());
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    public static implicit operator string(DocumentationContent documentationContent) => documentationContent.Value;

    public override bool Equals(object? obj)
    {
        if (obj is DocumentationFormat format)
        {
            return format.Value == Value;
        }

        return false;
    }
}