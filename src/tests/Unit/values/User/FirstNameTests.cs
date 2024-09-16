using domain.exceptions.User.FirstName;
using domain.models.user.values;

namespace Unit.values.User;

public class FirstNameTests
{
    [Fact]
    public void FirstName_Cannot_Be_Empty_Is_Failure()
    {
        // Arrange
        var value = string.Empty;
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void FirstName_Cannot_Be_Empty_Exception_Check()
    {
        // Arrange
        var value = string.Empty;
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is FirstNameEmptyException);
    }
    
    [Fact]
    public void FirstName_Cannot_Be_Too_Short_Is_Failure()
    {
        // Arrange
        var value = "a";
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void FirstName_Cannot_Be_Too_Short_Exception_Check()
    {
        // Arrange
        var value = "a";
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is FirstNameTooShortException);
    }

    [Fact]
    public void FirstName_Cannot_Be_Too_Long_Is_Failure()
    {
        // Arrange
        var value = "A".PadRight(26, 'A');
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void FirstName_Cannot_Be_Too_Long_Exception_Check()
    {
        // Arrange
        var value = "A".PadRight(26, 'A');
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is FirstNameTooLongException);
    }
    
    [Fact]
    public void FirstName_Can_Be_Created()
    {
        // Arrange
        var value = "John";
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void FirstName_Can_Be_Created_Exception_Check()
    {
        // Arrange
        var value = "John";
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Errors);
    }
    
    [Fact]
    public void FirstName_Can_Be_Created_Value_Check()
    {
        // Arrange
        var value = "John";
        
        // Act
        var result = FirstName.Create(value);
        
        //Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value.Value);
    }
}