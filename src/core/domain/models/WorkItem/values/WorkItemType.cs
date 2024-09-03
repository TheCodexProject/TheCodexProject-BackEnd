namespace domain.models.workItem.values;

/// <summary>
/// An enumeration of the different types of work items.
/// </summary>
public enum WorkItemType
{
    /// <summary>
    /// The work item is a task. (Default)
    /// </summary>
    Task,
    
    /// <summary>
    /// The work item is a bug report
    /// </summary>
    Bug,
    
    /// <summary>
    /// The work item is a feature request
    /// </summary>
    Feature,
    
    /// <summary>
    /// The work item is an improvement request.
    /// </summary>
    Improvement,
    
    /// <summary>
    /// The work item is a research task.
    /// </summary>
    Research,
    
    /// <summary>
    /// The work item is a documentation task.
    /// </summary>
    Documentation
}