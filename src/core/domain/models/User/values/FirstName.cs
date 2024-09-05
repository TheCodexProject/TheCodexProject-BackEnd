using domain.exceptions.User.FirstName;
using OperationResult;

namespace domain.models.User.values;

public class FirstName
{
    public string Value { get; }
    
    private FirstName(string value)
    {
        Value = value;
    }
    
    public static Result<FirstName> Create(string value)
    {
        var result = Validate(value);
        
        if (result.IsFailure)
        {
            return Result<FirstName>.Failure(result.Errors.ToArray());
        }
        
        var firstName = new FirstName(value);
        
        return Result<FirstName>.Success(firstName);
    }
    
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();
        
        if(string.IsNullOrWhiteSpace(value))
        {
            errors.Add(new FirstNameEmptyException());
            return Result.Failure(errors.ToArray());
        }
        
        if(value.Length < 2)
        {
            errors.Add(new FirstNameTooShortException());
            return Result.Failure(errors.ToArray());
        }
        
        if(value.Length > 25)
        {
            errors.Add(new FirstNameTooLongException());
            return Result.Failure(errors.ToArray());
        }
        
        return Result.Success();
    }
}