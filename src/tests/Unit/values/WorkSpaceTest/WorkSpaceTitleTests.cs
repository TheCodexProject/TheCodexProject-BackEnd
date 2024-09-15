using domain.exceptions.Workspace.WorkspaceTitle;
using domain.models.Workspace.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit.values.WorkSpaceTest;

public class WorkSpaceTitleTests
{
    /// <summary>
    /// Test to check if WorkSpaceTitle value object will let you create an empty title.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_Empty_Is_Failure()
    {
        // Arrange
        var value = string.Empty;

        // Act
        var result = WorkspaceTitle.Create(value);

        //Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct exception.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_Empty_Exception_Check()
    {
        // Arrange
        var value = string.Empty;

        // Act
        var result = WorkspaceTitle.Create(value);

        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is WorkspaceTitleEmptyException);
    }

    /// <summary>
    /// Test to check that you cannot create a title with less than 3 characters.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_Less_Than_Three_Characters_Is_Failure()
    {
        // Arrange
        var value = "A".PadRight(2, 'A');

        // Act
        var result = WorkspaceTitle.Create(value);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct expection.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_Less_Than_Three_Characters_Exception_Check()
    {
        // Arrange
        var value = "A".PadRight(2, 'A');

        // Act
        var result = WorkspaceTitle.Create(value);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is WorkspaceTitleTooShortException);
    }

    /// <summary>
    /// Test to check that you are allowed to create a title with 3 characters.
    /// </summary>
    [Fact]
    public void Title_Can_Be_Created_With_3_Characters()
    {
        // Arrange
        var value = "A".PadRight(3, 'A');

        // Act
        var result = WorkspaceTitle.Create(value);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value);
    }

    /// <summary>
    /// Test to check that you cannot create a title with more than 10 characters.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_More_Than_10_Characters_Is_Failure()
    {
        // Arrange
        var value = "A".PadRight(10, 'A');

        // Act
        var result = WorkspaceTitle.Create(value);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct exception.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_More_Than_10_Characters_Exception_Check()
    {
        // Arrange
        var value = "A".PadRight(10, 'A');

        // Act
        var result = WorkspaceTitle.Create(value);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is WorkspaceTitleTooLongException);
    }

    /// <summary>
    /// Test to check that you are allow to create a title with 10 characters.
    /// </summary>
    [Fact]
    public void Title_Can_Be_Created_With_10_Characters()
    {
        // Arrange
        var value = "A".PadRight(9, 'A');

        // Act
        var result = WorkspaceTitle.Create(value);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value);
    }

    /// <summary>
    /// Test to check that you are allowed to create a title with 5 characters (Which is within the limits.)
    /// </summary>
    [Fact]
    public void Title_Can_Be_Created_With_5_Characters()
    {
        // Arrange
        var value = "A".PadRight(4, 'A');

        // Act
        var result = WorkspaceTitle.Create(value);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value);
    }
}
