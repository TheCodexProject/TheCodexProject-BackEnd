using domain.models.workItem.values;

namespace domain.models.workItem;

/// <summary>
/// This class holds the placeholder values for the <see cref="WorkItem"/>.
/// </summary>
public class WorkItemConstants
{
    /// <summary>
    /// The default title for a <see cref="WorkItem"/>. (No title)
    /// </summary>
    public static readonly WorkItemTitle DefaultTitle = WorkItemTitle.Create("No Title");
    
    /// <summary>
    /// The default description for a <see cref="WorkItem"/>. (No description)
    /// </summary>
    public static readonly WorkItemDescription DefaultDescription = WorkItemDescription.Create("No Description");
    
    /// <summary>
    /// The default status for a <see cref="WorkItem"/>. (Not started)
    /// </summary>
    public static readonly WorkItemStatus DefaultStatus = WorkItemStatus.NotStarted;
    
    /// <summary>
    /// The default priority for a <see cref="WorkItem"/>. (Low)
    /// </summary>
    public static readonly WorkItemPriority DefaultPriority = WorkItemPriority.Low;
    
    /// <summary>
    /// The default type for a <see cref="WorkItem"/>. (Task)
    /// </summary>
    public static readonly WorkItemType DefaultType = WorkItemType.Task;
}