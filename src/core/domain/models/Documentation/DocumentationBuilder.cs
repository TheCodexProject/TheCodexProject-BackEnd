using domain.exceptions.project.ProjectTitle;
using domain.exceptions;
using domain.models.documentation;
using domain.models.project;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.exceptions.documentation.documentationContent;
using domain.exceptions.documentation.documentationTitle;

namespace domain.models.documentation;

public class DocumentationBuilder
{
    private readonly Documentation _documentation = Documentation.Create();
    private List<Exception> _errors = new();

    public static DocumentationBuilder Create()
    {
        return new DocumentationBuilder();
    }

    public Result<Documentation> MakeDefault()
    {
        return new DocumentationBuilder()
            .WithTitle(DocumentationConstants.DefaultTitle)
            .WithFormat(DocumentationConstants.DefaultFormat)
            .WithContent(DocumentationConstants.DefaultContent)
            .Build();
    }

    public DocumentationBuilder WithTitle(string title)
    {
        var result = _documentation.UpdateTitle(title);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public DocumentationBuilder WithFormat(string format)
    {
        var result = _documentation.UpdateFormat(format);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public DocumentationBuilder WithContent(string content)
    {
        var result = _documentation.UpdateContent(content);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public Result<Documentation> Build()
    {
        // ? Check if there are any ProjectTitleEmptyExceptions in the errors list.
        if (_errors.Any(e => e is DocumentationTitleEmptyException))
        {
            // * Take out the WorkItemTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is DocumentationTitleEmptyException);

            // * Remove the ProjectTitleEmptyException from the errors list.
            _errors.Remove(error);

            // * Create a new RequiredFieldMissingException with the ProjectTitleEmptyExceptions as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
            _errors.Insert(0, requiredFieldMissingException);
        }
        else if (_errors.Any(e => e is DocumentationContentEmptyException))
        {
            // * Take out the WorkItemTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is DocumentationContentEmptyException);

            // * Remove the ProjectTitleEmptyException from the errors list.
            _errors.Remove(error);

            // * Create a new RequiredFieldMissingException with the ProjectTitleEmptyExceptions as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Content is required.", error);
            _errors.Insert(0, requiredFieldMissingException);
        }

        return _errors.Any() ? Result<Documentation>.Failure(_errors.ToArray()) : _documentation;
    }
}
