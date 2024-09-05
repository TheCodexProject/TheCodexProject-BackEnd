using domain.exceptions.User.LastName;
using OperationResult;

namespace domain.models.Users.values;

public class LastName
{
    public string Value { get; }
    
    private LastName(string value)
    {
        Value = value;
    }
    
    public static Result<LastName> Create(string value)
    {
        var result = Validate(value);
        
        if (result.IsFailure)
        {
            return Result<LastName>.Failure(result.Errors.ToArray());
        }
        
        var lastName = new LastName(value);
        
        return Result<LastName>.Success(lastName);
    }
    
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();
        
        if(string.IsNullOrWhiteSpace(value))
        {
            errors.Add(new LastNameEmptyException());
            return Result.Failure(errors.ToArray());
        }
        
        if(value.Length < 2)
        {
            errors.Add(new LastNameTooShortException());
            return Result.Failure(errors.ToArray());
        }
        
        if(value.Length > 60)
        {
            errors.Add(new LastNameTooLongException());
            return Result.Failure(errors.ToArray());
        }
        
        return Result.Success();
    }
}