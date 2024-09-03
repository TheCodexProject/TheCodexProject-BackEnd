namespace domain.models.workItem.values;

/// <summary>
/// An enum representing the status of a work item.
/// </summary>
public enum WorkItemStatus
{
    /// <summary>
    /// The work item has not been started yet.
    /// </summary>
    NotStarted,
    
    /// <summary>
    /// The work item is currently in progress.
    /// </summary>
    InProgress,
    
    /// <summary>
    /// The work item has been completed.
    /// </summary>
    Completed,
    
    /// <summary>
    /// The work item is blocked and cannot be progressed.
    /// </summary>
    Blocked,
    
    /// <summary>
    /// The work item has been archived.
    /// </summary>
    Archived
}