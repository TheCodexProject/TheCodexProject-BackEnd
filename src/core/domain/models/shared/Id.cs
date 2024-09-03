namespace domain.models.shared;

public class Id<T>
{
    public Guid Value { get; private protected set; }
    
    protected Id()
    {
        Value = Guid.NewGuid(); 
    }
    
    public static implicit operator Guid(Id<T> id) => id.Value;
}