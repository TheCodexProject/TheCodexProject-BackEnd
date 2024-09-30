using domain.exceptions;
using domain.exceptions.project.ProjectDescription;
using domain.exceptions.project.ProjectTitle;
using domain.models.project;
using domain.models.project.values;

namespace Unit.values.project;

public class ProjectBuilderTests
{
    /// <summary>
    /// Test to see that a Project is created with default values.
    /// </summary>
    [Fact]
    public void Create_Project_With_Default_Values_Should_Have_Default_Values()
    {
        // Arrange & Act
        var project = ProjectBuilder.Create()
            .MakeDefault();

        // Assert
        Assert.True(project.IsSuccess);
        Assert.Equal(ProjectConstants.DefaultTitle, project.Value.ProjectTitle);
        Assert.Equal(ProjectConstants.DefaultDescription, project.Value.ProjectDescription);
        Assert.Equal(ProjectConstants.DefaultStatus, project.Value.ProjectStatus);
        Assert.Equal(ProjectConstants.DefaultPriority, project.Value.ProjectPriority);
        Assert.Equal(ProjectConstants.DefaultMethodology, project.Value.ProjectMethodology);
        Assert.Equal(ProjectConstants.DefaultStartTime, project.Value.ProjectStartTime);
        Assert.Equal(ProjectConstants.DefaultEndTime, project.Value.ProjectEndTime);
    }

    /// <summary>
    /// Test to see that creating a Project with a empty title fails.
    /// </summary>
    [Fact]
    public void ProjectBuilder_Builds_With_Empty_Required_Fields_Successfully()
    {
        // Arrange
        var builder = ProjectBuilder.Create();

        // Act
        var result = builder
            .WithTitle("")
            .Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to see that creating a Project with a null title fails.
    /// </summary>
    [Fact]
    public void Create_Project_With_Null_Title_Should_Fail()
    {
        // Act
        var project = ProjectBuilder.Create()
            .WithTitle(null)
            .Build();

        // Assert
        Assert.True(project.IsFailure);
        Assert.Contains(project.Errors, e => e is RequiredFieldMissingException);
    }

    /// <summary>
    /// Test to see that creating a Project with a title that is too short fails.
    /// </summary>
    [Fact]
    public void Create_Project_With_Short_Title_Should_Fail()
    {
        // Arrange
        var shortTitle = "a"; // Assuming the title should be longer than 1 character

        // Act
        var project = ProjectBuilder.Create()
            .WithTitle(shortTitle)
            .Build();

        // Assert
        Assert.True(project.IsFailure);
        Assert.Contains(project.Errors, e => e is ProjectTitleTooShortException);
    }

    /// <summary>
    /// Test to see that creating a Project with an empty description succeeds.
    /// </summary>
    [Fact]
    public void Create_Project_With_Empty_Description_Should_Succeed()
    {
        // Arrange
        var emptyDescription = string.Empty;

        // Act
        var project = ProjectBuilder.Create()
            .WithTitle("Title")
            .WithDescription("")
            .Build();

        // Assert
        Assert.True(project.IsSuccess);
        Assert.Equal(emptyDescription, project.Value.ProjectDescription);
    }
}