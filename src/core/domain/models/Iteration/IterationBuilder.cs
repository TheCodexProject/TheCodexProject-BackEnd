using domain.exceptions;
using domain.interfaces;
using domain.models.workspace;
using OperationResult;
using domain.exceptions.iteration.iterationTitle;
using domain.models.workItem;
using System.Linq.Expressions;

namespace domain.models.iteration;

public class IterationBuilder : IBuilder<Iteration>
{
    private readonly Iteration _iteration = Iteration.Create();
    private readonly List<Exception> _errors = new();


    /// <summary>
    /// The private constructor for the <see cref="IterationBuilder"/> class.
    /// </summary>
    private IterationBuilder() { }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="IterationBuilder"/> class.
    /// </summary>
    /// <param name="value">Title to use.</param>
    /// <returns>A <see cref="IterationBuilder"/></returns>
    public static IterationBuilder Create()
    {
        return new IterationBuilder();
    }

    /// <summary>
    /// Function to add title to the build of <see cref="WorkspaceBuilder"/>.
    /// </summary>
    /// <param name="value">Title to use.</param>
    public IterationBuilder withTitle(string title)
    {
        var result = _iteration.UpdateTitle(title);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    /// <summary>
    /// Adds a list of Workitems to the iteration.
    /// </summary>
    /// <param name="workItems">workItems to be set.</param>
    /// <returns></returns>
    public IterationBuilder WithWorkitems(List<WorkItem> workItems)
    {
        foreach (var workItem in workItems)
        {
            var result = _iteration.AddWorkItem(workItem);

            if (result.IsFailure)
            {
                _errors.AddRange(result.Errors);
            }
        }

        return this;
    }


    /// <summary>
    /// Function to the build <see cref="IterationBuilder"/>.
    /// </summary>
    public Result<Iteration> Build()
    {

        // Required fields
        if (_errors.Any(e => e is IterationTitleEmptyException))
        {
            // * Take out the WorkspaceTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is IterationTitleEmptyException);

            // * Remove the WorkspaceTitleEmptyException from the errors list.
            _errors.Remove(error);

            // * Create a new RequiredFieldMissingException with the WorkspaceTitleEmptyException as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
            _errors.Insert(0, requiredFieldMissingException);

        }
        else
        {
            if (_iteration.Title == null)
            {
                _errors.Add(new RequiredFieldMissingException("Title is required", new IterationTitleEmptyException()));
            }
        }

        return _errors.Any() ? Result<Iteration>.Failure(_errors.ToArray()) : _iteration;
    }

    /// <summary>
    /// Function to the build with some default values <see cref="IterationBuilder"/>.
    /// </summary>
    public Result<Iteration> MakeDefault()
    {
        return new IterationBuilder().withTitle(IterationConstants.DefaultTitle).Build();
    }
}
