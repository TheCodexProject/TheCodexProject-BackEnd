using domain.exceptions;
using domain.exceptions.User.Email;
using domain.interfaces;
using OperationResult;

namespace domain.models.user;

/// <summary>
/// A builder class for the <see cref="User"/> class.
/// </summary>
public class UserBuilder : IBuilder<User>
{
    /// <summary>
    /// The user that is being built.
    /// </summary>
    private readonly User _user = User.Create();
    private readonly List<Exception> _errors = new();
    
    /// <summary>
    /// Starts the creation of a new user.
    /// </summary>
    /// <returns></returns>
    public static UserBuilder Create()
    {
        return new UserBuilder();
    }
    
    /// <summary>
    /// Generates a default user with default values.
    /// </summary>
    /// <returns></returns>
    public Result<User> MakeDefault()
    {
        return new UserBuilder()
            .WithFirstName(UserConstants.FirstName)
            .WithLastName(UserConstants.LastName)
            .WithEmail(UserConstants.Email)
            .Build();
    }
    
    /// <summary>
    /// Sets the first name of the user.
    /// </summary>
    /// <param name="firstName">The first name to be set.</param>
    /// <returns></returns>
    public UserBuilder WithFirstName(string firstName)
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
    public UserBuilder WithLastName(string lastName)
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
    public UserBuilder WithEmail(string email)
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
        // ?Check if there are any EmailEmptyExceptions
        if(_errors.Any(e => e is EmailEmptyException))
        {
            // * Take out the EmailEmptyException from the errors and store it in a variable.
            var emailEmptyException = _errors.First(e => e is EmailEmptyException);
            
            // * Remove the EmailEmptyException from the errors.
            _errors.Remove(emailEmptyException);
            
            // * Add a new RequiredFieldMissingException to the errors as the first exception. (With the EmailEmptyException as the inner exception)
            var requiredFieldMissingException = new RequiredFieldMissingException("Email is required.", emailEmptyException);
            _errors.Insert(0, requiredFieldMissingException);
        }
        else
        {
            // ? If there are no EmailEmptyExceptions, check if the Email is null. (Since Email is a required field)
            if(_user.Email == null)
            {
                // * Add an RequiredFieldMissingException to the errors, since Email is required (+ Add the EmailEmptyException as the inner exception)
                _errors.Add(new RequiredFieldMissingException("Email is required.", new EmailEmptyException()));
            }
        }
        
        // ? Check if there are any errors in the list.
        return _errors.Any() ? Result<User>.Failure(_errors.ToArray()) : _user;
    }
}