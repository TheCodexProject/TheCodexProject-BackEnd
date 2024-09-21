using domain.exceptions.Id;
using domain.models.shared;
using OperationResult;

namespace Unit.values.Shared;

public class IdTests
{
    // Test to ensure that an ID is created with a value.
    [Fact]
    public void Create_Id_With_Value_Should_Have_Value()
    {
        // Arrange & Act
        var id = Id<string>.Create();
        
        // Assert
        Assert.NotNull(id);
        Assert.NotEqual(Guid.Empty, id.Value);
    }
    
    // Test to ensure that an ID is created with a value from a string, when valid.
    [Fact]
    public void Create_Id_With_String_Should_Have_Value_When_Valid()
    {
        // Arrange
        var guid = Guid.NewGuid();
        
        // Act
        var id = Id<string>.FromString(guid.ToString());
        
        // Assert
        Assert.NotNull(id);
        Assert.True(id.IsSuccess);
        Assert.Equal(guid, id.Value);
    }
    
    // Test to ensure than an ID is not created with a value from a string, when invalid.
    [Fact]
    public void Create_Id_With_String_Should_Not_Have_Value_When_Invalid()
    {
        // Arrange
        var invalidGuid = "invalid-guid";
        
        // Act
        var id = Id<string>.FromString(invalidGuid);
        
        // Assert
        Assert.True(id.IsFailure);
        Assert.Contains(id.Errors, e => e is IdConversionExpection);
    }
    
    
    // Test to ensure that an ID is created with a value from a Guid, when valid.
    [Fact]
    public void Create_Id_With_Guid_Should_Have_Value()
    {
        // Arrange
        var guid = Guid.NewGuid();
        
        // Act
        var id = Id<string>.FromGuid(guid);
        
        // Assert
        Assert.NotNull(id);
        Assert.Equal(guid, id.Value);
    }
    
    // Test to ensure that the implicit conversion from ID to Guid works.
    [Fact]
    public void Implicit_Conversion_From_Id_To_Guid_Should_Work()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = Id<string>.FromGuid(guid);
        
        // Act
        Guid result = id;
        
        // Assert
        Assert.Equal(guid, result);
    }
}