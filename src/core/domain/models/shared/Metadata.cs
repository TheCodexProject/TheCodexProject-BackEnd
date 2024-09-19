namespace domain.models.shared;

/// <summary>
/// A class that holds the metadata for objects within the system.
/// </summary>
public class Metadata
{
    /// <summary>
    /// Holds the date and time when the WorkItem was created. (No modifiable)
    /// </summary>
    public DateTime CreatedAt { get; }
    
    // NOTE: Should maybe be switched out for an Email or User object?
    /// <summary>
    /// Holds the user who created the WorkItem. (No modifiable)
    /// </summary>
    public string CreatedBy { get; private set; }
    
    /// <summary>
    /// Holds the date and time when the WorkItem was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }
    
    // NOTE: Should maybe be switched out for an Email or User object?
    /// <summary>
    /// Holds the user who last updated the WorkItem.
    /// </summary>
    public string? UpdatedBy { get; private set; }
    
    /// <summary>
    /// A private constructor to prevent the creation of Metadata without a user.
    /// </summary>
    private Metadata()
    {
        CreatedAt = DateTime.UtcNow;
    }
    
    /// <summary>
    /// A factory method to create a new instance of Metadata with the user who created the WorkItem.
    /// </summary>
    /// <param name="createdBy"></param>
    /// <returns></returns>
    public static Metadata Create(string createdBy)
    {
        return new Metadata
        {
            CreatedBy = createdBy
        };
    }
    
    /// <summary>
    /// Updates the Metadata with the user who updated the WorkItem and the date and time of the update.
    /// </summary>
    /// <param name="updatedBy"></param>
    public void Update(string updatedBy)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = updatedBy;
    }
}