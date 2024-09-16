using domain.exceptions.Id;
using OperationResult;

namespace domain.models.shared;

public class Id<T>
{
    /// <summary>
    /// The unique identifier of the entity.
    /// </summary>
    public Guid Value { get; private set; }
    
    /// <summary>
    /// The default constructor of the <see cref="Id{T}"/> class.
    /// </summary>
    private Id()
    {
        Value = Guid.NewGuid();
    }
    
    /// <summary>
    /// The factory method to create a new instance of the <see cref="Id{T}"/> class.
    /// </summary>
    /// <returns></returns>
    public static Id<T> Create()
    {
        return new Id<T>();
    }

    /// <summary>
    /// A factory method to create a new instance of the <see cref="Id{T}"/> class from a string.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Result<Id<T>> FromString(string id)
    {
        if(Guid.TryParse(id, out var guid))
        {
            return Result<Id<T>>.Success(new Id<T> { Value = guid });
        }
        
        return Result<Id<T>>.Failure(new IdConversionExpection());
    }
    
    /// <summary>
    /// A factory method to create a new instance of the <see cref="Id{T}"/> class from a <see cref="Guid"/>.
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static Id<T> FromGuid(Guid guid) => new() { Value = guid };
    
    /// <summary>
    /// Implicitly converts the <see cref="Id{T}"/> to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static implicit operator Guid(Id<T> id) => id.Value;
}