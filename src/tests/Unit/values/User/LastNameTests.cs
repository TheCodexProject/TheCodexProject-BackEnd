using domain.exceptions.User.LastName;
using domain.models.Users.values;

namespace Unit.values.User;

public class LastNameTests
{
    [Fact]
    public void LastName_Cannot_Be_Empty_Is_Failure()
    {
        // Arrange
        var value = string.Empty;
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void LastName_Cannot_Be_Empty_Exception_Check()
    {
        // Arrange
        var value = string.Empty;
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is LastNameEmptyException);
    }
    
    [Fact]
    public void LastName_Cannot_Be_Too_Short_Is_Failure()
    {
        // Arrange
        var value = "a";
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void LastName_Cannot_Be_Too_Short_Exception_Check()
    {
        // Arrange
        var value = "a";
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is LastNameTooShortException);
    }

    [Fact]
    public void LastName_Cannot_Be_Too_Long_Is_Failure()
    {
        // Arrange
        var value = "A".PadRight(61, 'A');
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void LastName_Cannot_Be_Too_Long_Exception_Check()
    {
        // Arrange
        var value = "A".PadRight(61, 'A');
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is LastNameTooLongException);
    }
    
    [Fact]
    public void LastName_Can_Be_Created()
    {
        // Arrange
        var value = "Johnson";
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void LastName_Can_Be_Created_Exception_Check()
    {
        // Arrange
        var value = "Johnson";
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Errors);
    }
    
    [Fact]
    public void LastName_Can_Be_Created_Value_Check()
    {
        // Arrange
        var value = "Johnson";
        
        // Act
        var result = LastName.Create(value);
        
        //Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value.Value);
    }
}