using domain.exceptions.User.Email;
using domain.models.Users.values;

namespace Unit.values.User;

public class EmailTests
{
    
    [Fact]
    public void Email_Cannot_Be_Empty_Is_Failure()
    {
        // Arrange
        var value = string.Empty;
        
        // Act
        var result = Email.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void Email_Cannot_Be_Empty_Exception_Check()
    {
        // Arrange
        var value = string.Empty;
        
        // Act
        var result = Email.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is EmailEmptyException);
    }
    
    [Fact]
    public void Email_Cannot_Be_Invalid_Is_Failure()
    {
        // Arrange
        var value = "invalid email";
        
        // Act
        var result = Email.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void Email_Cannot_Be_Invalid_Exception_Check()
    {
        // Arrange
        var value = "invalid@email";
        
        // Act
        var result = Email.Create(value);
        
        //Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is EmailInvalidException);
    }
    
    /// <summary>
    /// Ensures that you cannot create an email is missing a part or contains invalid characters.
    /// </summary>
    /// <param name="email">example to be tested</param>
    /// <param name="expected">the expected result.</param>
    [Theory]
    [InlineData("missing_at_symbol.com", true)]  // Missing @ symbol
    [InlineData("@domain.com", true)]  // Empty local part
    [InlineData("localpart@", true)]  // Empty domain part
    [InlineData("local@part@domain.com", true)]  // Multiple @ symbols
    [InlineData("special&character@domain.com", true)]  // Invalid special character in local part
    [InlineData("localpart@dom#ain.com", true)]  // Special character in domain part
    [InlineData("space in a local part@domain.com",true)]
    public void Invalid_Characters_And_Missing_Parts_Should_Fail(string email, bool expected)
    {
        // Act
        var result = Email.Create(email);
        
        //Assert
        Assert.Equal(expected, result.IsFailure);
    }
    
    /// <summary>
    /// Ensures that the email is the appropriate length.
    /// </summary>
    /// <param name="email">example to be tested.</param>
    /// <param name="expected">the expected result.</param>
    [Theory]
    [InlineData("this_is_way_too_long_for_gmail_to_accept_as_a_local_part_of_an_email@domain.com", true)]  // Local part too long
    [InlineData("validlocalpart@domainwithaveryveryveryveryveryveryveryveryveryveryverylongsegment.com", true)]  // Domain part too long
    [InlineData("valid.email@domain.com", false)]  // Valid email
    [InlineData("a@b.com", false)]  // Short but valid email
    public void Length_Constraints_Check(string email, bool expected)
    {
        // Act
        var result = Email.Create(email);
        
        //Assert
        Assert.Equal(expected, result.IsFailure);
    }

    /// <summary>
    /// Ensures that the email does not contain consecutive dots or start/end with a dot.
    /// </summary>
    /// <param name="email">example to be tested.</param>
    /// <param name="expected">the expected result.</param>
    [Theory]
    [InlineData("local..part@domain.com", true)] // Consecutive dots in local part
    [InlineData("localpart@domain..com", true)] // Consecutive dots in domain part
    [InlineData(".localpart@domain.com", true)] // Local part starts with a dot
    [InlineData("localpart.@domain.com", true)] // Local part ends with a dot
    [InlineData("valid.email@domain.com", false)] // Valid email with proper dots
    public void Dot_Usage_Check(string email, bool expected)
    {
        // Act
        var result = Email.Create(email);
        
        //Assert
        Assert.Equal(expected, result.IsFailure);
    }

    /// <summary>
    /// Ensures that the email domain does not contain a TLD that is too short.
    /// </summary>
    /// <param name="email">example to be tested.</param>
    /// <param name="expected">the expected result.</param>
    [Theory]
    [InlineData("localpart@domain.c", true)] // TLD too short
    [InlineData("localpart@domain.com", false)] // Valid TLD
    [InlineData("localpart@short.co", false)] // Valid short TLD
    public void TLDs_Check(string email, bool expected)
    {
        // Act
        var result = Email.Create(email);
        
        //Assert
        Assert.Equal(expected, result.IsFailure);
    }
}