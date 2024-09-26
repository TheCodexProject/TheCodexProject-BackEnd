using domain.exceptions;
using domain.exceptions.milestone.milestoneTitle;
using Microsoft.VisualBasic;
using OperationResult;

namespace domain.models.milestone;

public class MilestoneBuilder
{
    private readonly Milestone _milestone = Milestone.Create();
    private readonly List<Exception> _errors = new();

    /// <summary>
    /// The private constructor for the <see cref="MilestoneBuilder"/> class.
    /// </summary>
    private MilestoneBuilder() { }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="MilestoneBuilder"/> class.
    /// </summary>
    /// <returns>A <see cref="MilestoneBuilder"/></returns>
    public static MilestoneBuilder Create()
    {
        return new MilestoneBuilder();
    }

    public Result<Milestone> MakeDefault()
    {
        return new MilestoneBuilder()
            .WithTitle(MilestoneConstants.DefaultTitle)
            .Build();
    }

    /// <summary>
    /// Function to add title to the build of <see cref="MilestoneBuilder"/>.
    /// </summary>
    /// <param name="title">Title to use.</param>
    public MilestoneBuilder WithTitle(string title)
    {
        var result = _milestone.UpdateTitle(title);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    /// <summary>
    /// Function to the build <see cref="MilestoneBuilder"/>.
    /// </summary>
    public Result<Milestone> Build()
    {

        // Required fields
        if (_errors.Any(e => e is MilestoneTitleEmptyException))
        {
            // * Take out the WorkspaceTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is MilestoneTitleEmptyException);

            // * Remove the WorkspaceTitleEmptyException from the errors list.
            _errors.Remove(error);

            // * Create a new RequiredFieldMissingException with the WorkspaceTitleEmptyException as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
            _errors.Insert(0, requiredFieldMissingException);

        }
        else
        {
            if (_milestone.Title == null)
            {
                _errors.Add(new RequiredFieldMissingException("Title is required", new MilestoneTitleEmptyException()));
            }
        }

        return _errors.Any() ? Result<Milestone>.Failure(_errors.ToArray()) : _milestone;
    }
}