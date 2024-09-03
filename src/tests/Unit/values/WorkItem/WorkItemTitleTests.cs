using domain.exceptions.WorkItem.WorkItemTitle;
using domain.models.workItem.values;
using OperationResult;

namespace Unit.Values.WorkItem;

public class WorkItemTitleTests
{
    /// <summary>
    /// Test to check if WorkItemTitle value object will let you create an empty title.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_Empty_Is_Failure()
    {
        // Arrange
        var value = string.Empty;
        
        // Act
        var result = WorkItemTitle.Create(value);
        
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
        var result = WorkItemTitle.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is WorkItemTitleEmptyException);
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
        var result = WorkItemTitle.Create(value);

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
        var result = WorkItemTitle.Create(value);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is WorkItemTitleTooShortException);
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
        var result = WorkItemTitle.Create(value);

        // Assert
        Assert.False(result.IsFailure);
        Assert.Equal(value,result.Value);
    }
    
    /// <summary>
    /// Test to check that you cannot create a title with more than 75 characters.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_More_Than_75_Characters_Is_Failure()
    {
        // Arrange
        var value = "A".PadRight(76, 'A');
        
        // Act
        var result = WorkItemTitle.Create(value);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct exception.
    /// </summary>
    [Fact]
    public void Title_Cannot_Be_More_Than_75_Characters_Exception_Check()
    {
        // Arrange
        var value = "A".PadRight(76, 'A');
        
        // Act
        var result = WorkItemTitle.Create(value);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is WorkItemTitleTooLongException);
    }
    
    /// <summary>
    /// Test to check that you are allow to create a title with 75 characters.
    /// </summary>
    [Fact]
    public void Title_Can_Be_Created_With_75_Characters()
    {
        // Arrange
        var value = "A".PadRight(75, 'A');
        
        // Act
        var result = WorkItemTitle.Create(value);

        // Assert
        Assert.False(result.IsFailure);
        Assert.Equal(value,result.Value);
    }
    
    /// <summary>
    /// Test to check that you are allowed to create a title with 25 characters (Which is within the limits.)
    /// </summary>
    [Fact]
    public void Title_Can_Be_Created_With_25_Characters()
    {
        // Arrange
        var value = "A".PadRight(25, 'A');
        
        // Act
        var result = WorkItemTitle.Create(value);

        // Assert
        Assert.False(result.IsFailure);
        Assert.Equal(value,result.Value);
    }
}