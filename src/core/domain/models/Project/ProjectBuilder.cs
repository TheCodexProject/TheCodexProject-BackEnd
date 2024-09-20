using domain.exceptions;
using domain.exceptions.project.ProjectTitle;
using domain.models.project.values;
using domain.models.Users;
using domain.models.workItem.values;
using OperationResult;
using System.Reflection;

namespace domain.models.project;

/// <summary>
/// The ProjectBuilder can be used to create different types of "Template" Projects.
/// Used primarily for testing purposes.
/// </summary>
public class ProjectBuilder
{
    /// <summary>
    /// The Project that is being created.
    /// </summary>
    private readonly Project _project = Project.Create();
    private List<Exception> _errors = new();

    /// <summary>
    /// Initializes the creation of a new <see cref="Project"/>
    /// </summary>
    /// <returns></returns>
    public static ProjectBuilder Create()
    {
        return new ProjectBuilder();
    }

    public Result<Project> MakeDefault()
    {
        return new ProjectBuilder()
            .WithTitle(ProjectConstants.DefaultTitle)
            .WithDescription(ProjectConstants.DefaultDescription)
            .WithStatus(ProjectConstants.DefaultStatus)
            .WithPriority(ProjectConstants.DefaultPriority)
            .WithMethodology(ProjectConstants.DefaultMethodology)
            .WithTimeRange(ProjectConstants.DefaultStartTime, ProjectConstants.DefaultEndTime)
            .Build();
    }

    public ProjectBuilder WithTitle(string title)
    {
        var result = _project.UpdateTitle(title);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public ProjectBuilder WithDescription(string description)
    {
        var result = _project.UpdateDescription(description);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public ProjectBuilder WithMethodology(ProjectMethodology methodology)
    {
        var result = _project.UpdateMethodology(methodology);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public ProjectBuilder WithStatus(ProjectStatus status)
    {
        var result = _project.UpdateStatus(status);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public ProjectBuilder WithTimeRange(DateTime startTime, DateTime endTime)
    {
        var result = _project.UpdateTimeRange(startTime, endTime);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public ProjectBuilder WithPriority(ProjectPriority priority)
    {
        var result = _project.UpdatePriority(priority);

        if (result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }

        return this;
    }

    public Result<Project> Build()
    {
        // ? Check if there are any ProjectTitleEmptyExceptions in the errors list.
        if (_errors.Any(e => e is ProjectTitleEmptyException))
        {
            // * Take out the WorkItemTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is ProjectTitleEmptyException);

            // * Remove the ProjectTitleEmptyException from the errors list.
            _errors.Remove(error);

            // * Create a new RequiredFieldMissingException with the ProjectTitleEmptyExceptions as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
            _errors.Insert(0, requiredFieldMissingException);
        }
        else
        {
            if (_project.ProjectTitle == null)
            {
                _errors.Add(new RequiredFieldMissingException("Title is required.", new ProjectTitleEmptyException()));
            }
        }

        return _errors.Any() ? Result<Project>.Failure(_errors.ToArray()) : _project;
    }
}