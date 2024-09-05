using System.Text.RegularExpressions;
using domain.exceptions.User.Email;
using OperationResult;

namespace domain.models.User.values;

public class Email
{
    public string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private Email() {}
    
    private Email(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="Email"/> class.
    /// </summary>
    /// <param name="value">Email to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<Email> Create(string value)
    {
        var result = Validate(value);
        
        if (result.IsFailure)
        {
            return Result<Email>.Failure(result.Errors.ToArray());
        }
        
        var email = new Email(value);
        
        return Result<Email>.Success(email);
    }

    /// <summary>
    /// Validates the email.
    /// </summary>
    /// <param name="value">Email to be validated</param>
    /// <returns>A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();
        
        // Check if the email is empty.
        if (string.IsNullOrWhiteSpace(value))
        {
            errors.Add(new EmailEmptyException());
            return Result.Failure(errors.ToArray());
        }

        if (!BasicFormatCheck(value))
        {
            errors.Add(new EmailInvalidException());
            return Result.Failure(errors.ToArray());
        }
        
        return Result.Success();
    }
    
    /// <summary>
    /// Checks if the email is in the correct format. (Not allowing special characters and spaces etc.)
    /// </summary>
    /// <param name="value">Value to check.</param>
    /// <returns></returns>
    private static bool BasicFormatCheck(string value)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        
        if (!Regex.IsMatch(value, pattern))
        {
            return false;
        }
        
        var parts = value.Split('@');
        if (parts.Length != 2)
        {
            return false;
        }

        var localPart = parts[0];
        var domainPart = parts[1];
        
        if (localPart.Length > 30 || value.Length > 254)
        {
            return false;
        }

        if (localPart.Contains("..") || domainPart.Contains(".."))
        {
            return false;
        }
        
        if (localPart.StartsWith(".") || localPart.EndsWith("."))
        {
            return false;
        }

        var domainParts = domainPart.Split('.');
        if (domainParts.Any(part => part.Length > 63))
        {
            return false;
        }


        return true;
    }


}