using System.Collections.ObjectModel;
using domain.exceptions.Organisation;
using domain.models.documentation;
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
    
    
    /// <summary>
    /// A list of the documentation of the organisation.
    /// </summary>
    private List<Documentation> _documentation { get; }

    /// <summary>
    /// Returns a read-only collection of the documentation of the organisation.
    /// </summary>
    public ReadOnlyCollection<Documentation> Documentation => _documentation.AsReadOnly();
    
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

    /// <summary>
    /// Adds the given owner to the organisation.
    /// </summary>
    /// <param name="owner">The owner to be added.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Removes the given owner from the organisation.
    /// </summary>
    /// <param name="owner">The owner to be removed.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Adds the given documentation to the organisation.
    /// </summary>
    /// <param name="documentation">The documentation to be added.</param>
    /// <returns></returns>
    public Result AddDocumentation(Documentation? documentation)
    {
        // ? Check if the documentation is null
        if(documentation == null)
        {
            return Result.Failure(new OrganisationDocumentationNotFoundException("The given documentation is null."));
        }

        // ? Check if the documentation is in the list?
        if(_documentation.Contains(documentation))
        {
            return Result.Failure(new OrganisationDocumentationAlreadyExistsException());
        }

        _documentation.Add(documentation);

        return Result.Success();
    }

    /// <summary>
    /// Removes the given documentation from the organisation.
    /// </summary>
    /// <param name="documentation">The documentation to be removed.</param>
    /// <returns></returns>
    public Result RemoveDocumentation(Documentation? documentation)
    {
        // ? Check if the documentation is null
        if(documentation == null)
        {
            return Result.Failure(new OrganisationDocumentationNotFoundException("The given documentation is null."));
        }

        // ? Check if the documentation is in the list?
        if(!_documentation.Contains(documentation))
        {
            return Result.Failure(new OrganisationDocumentationNotFoundException());
        }

        _documentation.Remove(documentation);

        return Result.Success();
    }
}