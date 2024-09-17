using domain.exceptions.User.Email;
using domain.models.user.values;
using OperationResult;

namespace domain.models.user;

/// <summary>
/// A builder class for the <see cref="User"/> class.
/// </summary>
public class UserBuilder
{
    /// <summary>
    /// The user that is being built.
    /// </summary>
    private User _user = User.Create();
    private List<Exception> _errors = new();
    
    /// <summary>
    /// Starts the creation of a new user.
    /// </summary>
    /// <returns></returns>
    public static UserBuilder Create()
    {
        return new UserBuilder();
    }
    
    /// <summary>
    /// Sets the first name of the user.
    /// </summary>
    /// <param name="firstName">The first name to be set.</param>
    /// <returns></returns>
    public Result<UserBuilder> WithFirstName(string firstName)
    {
        var result = _user.UpdateFirstName(firstName);
        
        if(result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }
        
        return this;
    }
    
    /// <summary>
    /// Sets the last name of the user.
    /// </summary>
    /// <param name="lastName">The last name to be set.</param>
    /// <returns></returns>
    public Result<UserBuilder> WithLastName(string lastName)
    {
        var result = _user.UpdateLastName(lastName);
        
        if(result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }
        
        return this;
    }
    
    /// <summary>
    /// Sets the email of the user.
    /// </summary>
    /// <param name="email">The email to be set.</param>
    /// <returns></returns>
    public Result<UserBuilder> WithEmail(string email)
    {
        var result = _user.UpdateEmail(email);
        
        if(result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }
        
        return this;
    }
    
    /// <summary>
    /// Returns the built user.
    /// </summary>
    /// <returns>A <see cref="User"/> with the specified values.</returns>
    public Result<User> Build()
    {
        // Check if there are any EmailEmptyExceptions
        if(_errors.Any(e => e is EmailEmptyException))
        {
            // If there is remove the EmailEmptyException from the errors.
            _errors.RemoveAll(e => e is EmailEmptyException);
            
            // Add a new RequiredFieldMissingException to the errors.
            // TODO ADD RequiredFieldMissingException INNER EmailEmptyException
        }
        else
        {
            // ! If there aren't any EmailEmptyExceptions.
            if(_user.Email == null)
            {
                // ! Add a new EmailEmptyException to the errors.
                // TODO ADD EmailEmptyException
            }
        }
        
        return _errors.Any() ? Result<User>.Failure(_errors.ToArray()) : _user;
    }
}