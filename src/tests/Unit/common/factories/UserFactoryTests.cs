using domain.models.Users;

namespace Unit.common.factories;

public class UserFactoryTests
{
    [Fact]
    public void Create_Empty_User_Should_Have_Id()
    {
        // Arrange
        var user = UserFactory.Create().Build();
        
        // Act
        var result = user.Id;

        // Assert
        Assert.NotEqual(Guid.Empty, result);
    }
    
    [Fact]
    public void Create_User_With_First_Name_Should_Have_First_Name()
    {
        // Arrange
        const string firstName = "Bob";
        
        // Act
        var user = UserFactory.Create()
            .WithFirstName(firstName)
            .Build();
        
        var result = user.FirstName.Value;
        
        // Assert
        Assert.Equal(firstName, result);
    }
    
    [Fact]
    public void Create_User_With_Last_Name_Should_Have_Last_Name()
    {
        // Arrange
        const string lastName = "Bobsen";
        
        // Act
        var user = UserFactory.Create()
            .WithLastName(lastName)
            .Build();
        
        var result = user.LastName.Value;
        
        // Assert
        Assert.Equal(lastName, result);
    }
    
    [Fact]
    public void Create_User_With_First_And_Last_Name_Should_Have_Full_Name()
    {
        // Arrange
        const string firstName = "Bob";
        const string lastName = "Bobsen";
        
        // Act
        var user = UserFactory.Create()
            .WithFirstName(firstName)
            .WithLastName(lastName)
            .Build();
        
        var result = user.FullName;
        
        // Assert
        Assert.Equal($"{firstName} {lastName}", result);
    }

    [Fact]
    public void Create_User_With_Email_Should_Have_Email()
    {
        // Arrange
        const string email = "test@mail.dk";
        
        // Act
        var user = UserFactory.Create()
            .WithEmail(email)
            .Build();
        
        var result = user.Email.Value;
        
        // Assert
        Assert.Equal(email, result);
    }

    [Fact]
    public void Create_User_With_Multiple_Changes_Should_Match()
    {
        // Arrange
        const string firstName = "Bob";
        const string lastName = "Bobsen";
        const string email = "test@mail.dk";
        
        // Act
        var user = UserFactory.Create()
            .WithFirstName(firstName)
            .WithLastName(lastName)
            .WithEmail(email)
            .Build();
        
        var result = user;
        
        // Assert
        Assert.Equal(firstName, result.FirstName.Value);
        Assert.Equal(lastName, result.LastName.Value);
        Assert.Equal(email, result.Email.Value);
    }
}