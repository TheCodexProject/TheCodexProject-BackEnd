using domain.exceptions;
using domain.exceptions.Organisation;
using domain.exceptions.WorkItem.WorkItemTitle;
using domain.interfaces;
using domain.models.Interfaces;
using domain.models.user;
using OperationResult;

namespace domain.models.organisation;

public class OrganisationBuilder : IBuilder<Organisation>
{
    /// <summary>
    /// The organisation to be built.
    /// </summary>
    private readonly Organisation _organisation = Organisation.Create();

    /// <summary>
    /// A list of errors that occurred during the building process.
    /// </summary>
    private readonly List<Exception> _errors = new();
    
    /// <summary>
    /// Instantiates a new instance of <see cref="OrganisationBuilder"/>.
    /// </summary>
    /// <returns></returns>
    public static OrganisationBuilder Create()
    {
        return new OrganisationBuilder();
    }
    
    /// <summary>
    /// Makes a default organisation.
    /// </summary>
    /// <returns></returns>
    public Result<Organisation> MakeDefault()
    {
        // ? Should there even be owner as a part of the default Organisation?
       return new OrganisationBuilder()
           .WithName("Organisation")
           .WithOwner(User.Create())
           .Build();
    }
    
    /// <summary>
    /// Sets the name of the organisation.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public OrganisationBuilder WithName(string name)
    {
        var result = _organisation.UpdateName(name);
        
        if(result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }
        
        return this;
    }
    
    /// <summary>
    /// Sets the owner of the organisation.
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public OrganisationBuilder WithOwner(IOwnership owner)
    {
        var result = _organisation.AddOwner(owner);
        
        if(result.IsFailure)
        {
            _errors.AddRange(result.Errors);
        }
        
        return this;
    }
    
    /// <summary>
    /// Builds the organisation.
    /// </summary>
    /// <returns></returns>
    public Result<Organisation> Build()
    {
        // ? Check if there are any OrganisationNameEmptyException in the errors list.
        if (_errors.Any(e => e is OrganisationNameEmptyException))
        {
            // * Take out the WorkItemTitleEmptyException from errors and store it in a variable.
            var error = _errors.First(e => e is OrganisationNameEmptyException);
            
            // * Remove the OrganisationNameEmptyException from the errors list.
            _errors.Remove(error);
            
            // * Create a new RequiredFieldMissingException with the OrganisationNameEmptyException as the inner exception.
            var requiredFieldMissingException = new RequiredFieldMissingException("Name is required. 1",error);
            _errors.Insert(0,requiredFieldMissingException);
        }
        else
        {
            if(_organisation.Name == null)
            {
                _errors.Add(new RequiredFieldMissingException("Name is required.",new OrganisationNameEmptyException()));
            }
        }
        
        return _errors.Any() ? Result<Organisation>.Failure(_errors.ToArray()) : _organisation;
    }
}