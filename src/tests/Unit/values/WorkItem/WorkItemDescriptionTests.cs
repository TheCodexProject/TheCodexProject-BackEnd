using domain.exceptions.WorkItem.WorkItemDescription;
using domain.models.workItem.values;

namespace Unit.Values.WorkItem;

public class WorkItemDescriptionTests
{
    
    /// <summary>
    /// Test to check if WorkItemDescription value object will let you create an too long description.
    /// </summary>
    [Fact]
    public void Description_Cannot_Be_More_Than_500_Characters_Is_Failure()
    {
        // Arrange
        var description = new string('a', 501);
        
        // Act
        var result = WorkItemDescription.Create(description);
        
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
        var result = WorkItemDescription.Create(description);
        
        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is WorkItemDescriptionTooLongException);
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
        var result = WorkItemDescription.Create(description);
        
        // Assert
        Assert.False(result.IsFailure);
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
        var result = WorkItemDescription.Create(description);
        
        // Assert
        Assert.False(result.IsFailure);
    }
}