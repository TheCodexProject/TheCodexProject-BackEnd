using domain.exceptions.Organisation;
using OperationResult;

namespace domain.models.organisation.values;

public class OrganisationName
{
    /// <summary>
    /// The organisation name.
    /// </summary>
    private string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private OrganisationName() {}

    /// <summary>
    /// Private constructor for the <see cref="OrganisationName"/> class.
    /// </summary>
    /// <param name="value"></param>
    private OrganisationName(string value)
    {
        Value = value;
    }
    
    public static Result<OrganisationName> Create(string value)
    {
        var result = Validate(value);
        
        if (result.IsFailure)
        {
            return Result<OrganisationName>.Failure(result.Errors.ToArray());
        }
        
        var organisationName = new OrganisationName(value);
        
        return Result<OrganisationName>.Success(organisationName);
    }

    private static Result Validate(string value)
    {
        var errors = new List<Exception>();
        
        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new OrganisationNameEmptyException());
            return Result.Failure(errors.ToArray());
        }
        
        switch (value)
        {
            case { Length: < 2}:
                errors.Add(new OrganisationNameTooShortException());
                break;
            case { Length: > 100}:
                errors.Add(new OrganisationNameTooLongException());
                break;
        }
        
        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }
    
    public static implicit operator string(OrganisationName organisationName) => organisationName.Value;
    
    public override bool Equals(object? obj)
    {
        if(obj is OrganisationName name)
        {
            return name.Value == Value;
        }
        
        return false;
    }
}