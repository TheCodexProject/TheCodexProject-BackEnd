using domain.exceptions.project.ProjectDescription;
using domain.models.project.values;

namespace Unit.values.Project;

public class ProjectDescriptionTests
{
    /// <summary>
    /// Test to check if ProjectDescription value object will let you create an too long description.
    /// </summary>
    [Fact]
    public void Description_Cannot_Be_More_Than_500_Characters_Is_Failure()
    {
        // Arrange
        var description = new string('a', 501);

        // Act
        var result = ProjectDescription.Create(description);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct exception.
    /// </summary>
    [Fact]
    public void Description_Cannot_Be_More_Than_500_Characters_Exception_Check()
    {
        // Arrange
        var description = new string('a', 501);

        // Act
        var result = ProjectDescription.Create(description);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is ProjectDescriptionTooLongException);
    }


    /// <summary>
    /// Test to check that you are allow to create a description with 500 characters.
    /// </summary>
    [Fact]
    public void Description_Can_Be_500_Characters()
    {
        // Arrange
        var description = new string('a', 500);

        // Act
        var result = ProjectDescription.Create(description);

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Test to check that you are allow to create an empty description.
    /// </summary>
    [Fact]
    public void Description_Can_Be_Empty()
    {
        // Arrange
        var description = string.Empty;

        // Act
        var result = ProjectDescription.Create(description);

        // Assert
        Assert.True(result.IsSuccess);
    }
}