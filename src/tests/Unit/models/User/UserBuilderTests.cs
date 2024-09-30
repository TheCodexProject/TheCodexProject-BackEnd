using domain.exceptions;
using domain.exceptions.User.FirstName;
using domain.models.user;

namespace Unit.models.user;

public class UserBuilderTests
{
    // MakeDefault - Ensure the builder creates a default user with default values.
    [Fact]
    public void UserBuilder_Makes_Default_User_Successfully()
    {
        // Arrange
        var builder = UserBuilder.Create();
        
        // Act
        var result = builder
            .MakeDefault();
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(UserConstants.FirstName, result.Value.FirstName.Value);
        Assert.Equal(UserConstants.LastName, result.Value.LastName.Value);
        Assert.Equal(UserConstants.Email, result.Value.Email.Value);
    }
    
    // Chaining - Ensure the builder can chain the first name, last name, and email successfully.
    [Fact]
    public void UserBuilder_Chains_First_Last_Name_And_Email_Successfully()
    {
        // Arrange
        var builder = UserBuilder.Create();
        var firstName = "Jane";
        var lastName = "Doe";
        var email = "mail@different.com";

        // Act
        var result = builder
            .WithFirstName(firstName)
            .WithLastName(lastName)
            .WithEmail(email)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(firstName, result.Value.FirstName.Value);
        Assert.Equal(lastName, result.Value.LastName.Value);
        Assert.Equal(email, result.Value.Email.Value);
    }
    
    // Optional Fields - Ensure the builder can builder the user without the optional fields. (First Name, Last Name)
    [Fact]
    public void UserBuilder_Sets_Email_Successfully()
    {
        // Arrange
        var builder = UserBuilder.Create();
        var email = "mail@different.com";

        // Act
        var result = builder
            .WithEmail(email)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(email, result.Value.Email.Value);
    }
    
    // Empty Required Fields - Ensure the builder fails to build the user when required fields are empty. (Email)
    [Fact]
    public void UserBuilder_Fails_With_Empty_Required_Fields()
    {
        // Arrange
        var builder = UserBuilder.Create();
        var firstName = "Jane";
        var lastName = "Doe";
        var email = string.Empty;

        // Act
        var result = builder
            .WithFirstName(firstName)
            .WithLastName(lastName)
            .WithEmail(email)
            .Build();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
    }
    
    // Null Required Fields - Ensure the builder fails to build the user when required fields are null. (Email)
    [Fact]
    public void UserBuilder_Fails_With_Null_Required_Fields()
    {
        // Arrange
        var builder = UserBuilder.Create();
        string firstName = "Jane";
        string lastName = "Doe";
        string email = null;

        // Act
        var result = builder
            .WithFirstName(firstName)
            .WithLastName(lastName)
            .WithEmail(email)
            .Build();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
    }
    
    // Multiple Errors - Ensure the builder fails to build the user when multiple errors occur. (First Name, Last Name, Email)
    [Fact]
    public void UserBuilder_Fails_With_Multiple_Errors()
    {
        // Arrange
        var builder = UserBuilder.Create();
        string firstName = string.Empty;
        string lastName = "Doe";
        string email = null;

        // Act
        var result = builder
            .WithFirstName(firstName)
            .WithLastName(lastName)
            .WithEmail(email)
            .Build();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(result.Errors.Count() > 1);
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        Assert.Contains(result.Errors, e => e is FirstNameEmptyException);
    }
}