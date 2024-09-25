using domain.exceptions.Organisation;
using domain.models.organisation.values;

namespace Unit.values.Organisation;

public class OrganisationNameTests
{
    [Fact]
    public void Create_WithValidName_ShouldReturnSuccess()
    {
        // Arrange
        var name = "Organisation";
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void Create_WithValidName_ShouldReturnCorrectValue()
    {
        // Arrange
        var name = "Organisation";
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.Equal(name, result.Value);
    }
    
    [Fact]
    public void Create_WithEmptyName_ShouldReturnFailure()
    {
        // Arrange
        var name = string.Empty;
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void Create_WithNullName_ShouldReturnFailure()
    {
        // Arrange
        string name = null;
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void Create_WithWhitespaceName_ShouldReturnFailure()
    {
        // Arrange
        var name = " ";
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void Create_WithTooLongName_ShouldReturnFailure()
    {
        // Arrange
        var name = new string('a', 101);
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void Create_WithTooLongName_ShouldReturnCorrectError()
    {
        // Arrange
        var name = new string('a', 101);
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.Contains(result.Errors, e => e is OrganisationNameTooLongException);
    }
    
    [Fact]
    public void Create_WithTooShortName_ShouldReturnFailure()
    {
        // Arrange
        var name = new string('a', 1);
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void Create_WithTooShortName_ShouldReturnCorrectError()
    {
        // Arrange
        var name = new string('a', 1);
        
        // Act
        var result = OrganisationName.Create(name);
        
        // Assert
        Assert.Contains(result.Errors, e => e is OrganisationNameTooShortException);
    }
    
}