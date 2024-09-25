

using domain.models.organisation;
using domain.models.user;

namespace Unit.models.Organisation;

public class OrganisationBuilderTests
{
    [Fact]
    public void MakeDefault_ShouldReturnOrganisation()
    {
        // Arrange
        var builder = OrganisationBuilder.Create();
        
        // Act
        var result = builder.MakeDefault();
        
        // Assert
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void Chaining_ShouldReturnOrganisation()
    {
        // Arrange
        var builder = OrganisationBuilder.Create();
        var user = UserBuilder.Create().MakeDefault().Value;
        
        // Act
        var result = builder
            .WithName("Organisation")
            .WithOwner(user)
            .Build();
        
        // Assert
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void BuildWithoutOptionalFields_ShouldReturnOrganisation()
    {
        // Arrange
        var builder = OrganisationBuilder.Create();
        
        // Act
        var result = builder
            .WithName("Organisation")
            .Build();
        
        // Assert
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void BuildWithEmptyRequiredFields_ShouldReturnError()
    {
        // Arrange
        var builder = OrganisationBuilder.Create();
        
        // Act
        var result = builder.Build();
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void BuildWithNullRequiredFields_ShouldReturnError()
    {
        // Arrange
        var builder = OrganisationBuilder.Create();
        
        // Act
        var result = builder
            .WithName(null)
            .Build();
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void BuildWithTooShortName_ShouldReturnError()
    {
        // Arrange
        var builder = OrganisationBuilder.Create();
        
        // Act
        var result = builder
            .WithName("A")
            .Build();
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void BuildWithTooLongName_ShouldReturnError()
    {
        // Arrange
        var builder = OrganisationBuilder.Create();
        var name = new string('a', 101);
        
        // Act
        var result = builder
            .WithName(name)
            .Build();
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
}