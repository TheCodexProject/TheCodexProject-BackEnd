using domain.models.documentation.values;
using domain.models.documentation.values;
using domain.models.project;
using domain.models.shared;
using OperationResult;

namespace domain.models.documentation;

public class Documentation
{
    public Id<Documentation> Id { get; set; }

    public DocumentationTitle DocumentationTitle { get; private set; }

    public DocumentationFormat DocumentationFormat { get; private set; }

    private Documentation()
    {
        // "Specific" values
        Id = Id<Documentation>.Create();
    }

    public static Documentation Create()
    {
        return new Documentation();
    }

    public Result UpdateTitle(string value)
    {
        var newTitle = DocumentationTitle.Create(value);

        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the title?
        if (newTitle.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(newTitle.Errors.ToArray());
        }

        // Update the title.
        DocumentationTitle = newTitle.Value;

        return Result.Success();
    }

    public Result UpdateFormat(string format)
    {
        var newFormat = DocumentationFormat.Create(format);

        // ! VALIDATION
        // Are there any specific things that we would like to validate, when the user updates the description?
        if (newFormat.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(newFormat.Errors.ToArray());
        }

        // Update the format.
        DocumentationFormat = newFormat.Value;

        return Result.Success();
    }
}
