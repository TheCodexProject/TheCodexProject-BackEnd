using domain.models.shared;
using domain.models.user.values;
using OperationResult;

namespace domain.models.user;

public class User
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    public Id<User> Id { get; private set; }
    
    /// <summary>
    /// Holds the first name of the user.
    /// </summary>
    public FirstName? FirstName { get; private set; }
    
    /// <summary>
    /// Holds the last name of the user.
    /// </summary>
    public LastName? LastName { get; private set; }
    
    /// <summary>
    /// Holds the email of the user.
    /// </summary>
    public Email? Email { get; private set; }
    
    // TODO: Add a encrypted password property here, when working on authentication.

    /// <summary>
    /// Constructs a new instance of <see cref="User"/> with a set of default values.
    /// </summary>
    private User()
    {
        // "Specific" values
        Id = Id<User>.Create();
    }

    /// <summary>
    /// Creates a new instance of <see cref="User"/>.
    /// </summary>
    /// <returns></returns>
    public static User Create()
    {
        // ! No validation needed here
        // As the User can be modified through the provided methods.
        return new User();
    }
    
    /// <summary>
    /// Updates the first name of the user.
    /// </summary>
    /// <param name="firstName">The new first name.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateFirstName(string firstName)
    {
        var result = FirstName.Create(firstName);
        
        // ! Validation
        // Are there any specific things that we would like to validate, when the first name is updated?
        if (result.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(result.Errors.ToArray());
        }
        
        // Update the first name.
        FirstName = result;
        
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the last name of the user.
    /// </summary>
    /// <param name="lastName">The new last name</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateLastName(string lastName)
    {
        var result = LastName.Create(lastName);
        
        // ! Validation
        // Are there any specific things that we would like to validate, when the last name is updated?
        if (result.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(result.Errors.ToArray());
        }
        
        // Update the last name.
        LastName = result;
        
        return Result.Success();
    }
    
    /// <summary>
    /// Updates the email of the user.
    /// </summary>
    /// <param name="email">The new Email.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateEmail(string email)
    {
        var result = Email.Create(email);
        
        // ! Validation
        // Are there any specific things that we would like to validate, when the email is updated?
        if (result.IsFailure)
        {
            // ! Return the errors from the result.
            return Result.Failure(result.Errors.ToArray());
        }
        
        // Update the email.
        Email = result;
        
        return Result.Success();
    }
}