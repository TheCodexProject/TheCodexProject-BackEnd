using domain.models.Interfaces;
using domain.models.organisation.values;
using domain.models.shared;
using OperationResult;

namespace domain.models.organisation;

public class Organisation : IOwnership
{
    public Id<Organisation> Id { get; }
    
    public OrganisationName? Name { get; }
    
    public IEnumerable<IOwnership> Owners { get; }
    
    // TODO: Add the following property after merge.
    // public IEnumerable<Documentation> Docs { get; }
    
    private Organisation()
    {
        Id = Id<Organisation>.Create();
        Owners = new List<IOwnership>();
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
        
        return Result.Success();
    }

 
    // Should this even be a method? or just a part of the constructor?
    public Result AddOwner(IOwnership owner)
    {
        // What validation should be done here, if any?
        Owners.Append(owner);
        
        return Result.Success();
    }
}