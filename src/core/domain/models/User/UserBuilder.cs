using domain.models.user.values;

namespace domain.models.user;

/// <summary>
/// A builder class for the <see cref="User"/> class.
/// </summary>
public class UserBuilder
{
    /// <summary>
    /// The user that is being built.
    /// </summary>
    private User result = User.Create();
    
    /// <summary>
    /// Starts the creation of a new user.
    /// </summary>
    /// <returns></returns>
    public static UserBuilder create()
    {
        return new UserBuilder();
    }
    
    /// <summary>
    /// Sets the first name of the user.
    /// </summary>
    /// <param name="firstName">The first name to be set.</param>
    /// <returns></returns>
    public UserBuilder WithFirstName(string firstName)
    {
        result.UpdateFirstName(firstName);
        return this;
    }
    
    /// <summary>
    /// Sets the last name of the user.
    /// </summary>
    /// <param name="lastName">The last name to be set.</param>
    /// <returns></returns>
    public UserBuilder WithLastName(string lastName)
    {
        result.UpdateLastName(lastName);
        return this;
    }
    
    /// <summary>
    /// Sets the email of the user.
    /// </summary>
    /// <param name="email">The email to be set.</param>
    /// <returns></returns>
    public UserBuilder WithEmail(string email)
    {
        result.UpdateEmail(email);
        return this;
    }
    
    /// <summary>
    /// Returns the built user.
    /// </summary>
    /// <returns>A <see cref="User"/> with the specified values.</returns>
    public User Build()
    {
        return result;
    }
}