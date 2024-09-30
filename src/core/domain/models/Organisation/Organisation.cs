using System.Collections.ObjectModel;
using domain.exceptions.Organisation;
using domain.models.Interfaces;
using domain.models.organisation.values;
using domain.models.shared;
using OperationResult;

namespace domain.models.organisation;

public class Organisation : IOwnership
{
    /// <summary>
    /// The unique identifier of the organisation.
    /// </summary>
    public Id<Organisation> Id { get; private set; }
    
    /// <summary>
    /// The name of the organisation.
    /// </summary>
    public OrganisationName? Name { get; private set; }

    /// <summary>
    /// A list of the owners of the organisation.
    /// </summary>
    private List<IOwnership> _owners { get;  set; }
    
    /// <summary>
    /// Returns a read-only collection of the owners of the organisation.
    /// </summary>
    public ReadOnlyCollection<IOwnership> Owners => _owners.AsReadOnly();
    
    
    // TODO: Add the following property after merge.
    // public IEnumerable<Documentation> Docs { get; }
    
    private Organisation()
    {
        Id = Id<Organisation>.Create();
        _owners = new List<IOwnership>();
    }
    
    public static Organisation Create()
    {
        return new Organisation();
    }
    
    public Result UpdateName(string name)
    {
        var result = OrganisationName.Create(name);
        
        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }
        
        Name = result.Value;
        
        return Result.Success();
    }
    
    public Result AddOwner(IOwnership? owner)
    {
        // ! VALIDATION

        // ? Check if the owner is null
        if(owner == null)
        {
            return Result.Failure(new OrganisationOwnerNotFoundException("The given owner is null."));
        }

        // ? Check if the Owner is in the list?
        if(_owners.Contains(owner))
        {
            return Result.Failure(new OrganisationOwnerAlreadyExistsException());
        }

        // What validation should be done here, if any?
        _owners.Add(owner);
        
        return Result.Success();
    }
    
    public Result RemoveOwner(IOwnership? owner)
    {
        //! VALIDATION

        // ? Check if the owner is null
        if(owner == null)
        {
            return Result.Failure(new OrganisationOwnerNotFoundException("The given owner is null."));
        }


        // There needs to be at least one owner at all times for an organisation to exist.
        if (_owners.Count() == 1)
        {
                return Result.Failure(new OrganisationNeedsAnOwnerException());
        }
        
        // ? Check if the Owner is in the list?
        if(!_owners.Contains(owner))
        {
            return Result.Failure(new OrganisationOwnerNotFoundException());
        }
        
        // Remove the owner.
        _owners.Remove(owner);
        
        return Result.Success();
    }
}