using domain.models.documentation;
using domain.models.shared;
using domain.models.workItem.values;

namespace domain.models.workItem;

public static class WorkItemConstants
{
    /// <summary>
    /// A default title to be used for testing purposes.
    /// </summary>
    public const string Title = "Title";
    
    /// <summary>
    /// A default title to be used for testing purposes.
    /// </summary>
    public const string Description = "Description";
    
    /// <summary>
    /// A default status to be used for testing purposes.
    /// </summary>
    public const WorkItemStatus Status = WorkItemStatus.NotStarted;

    /// <summary>
    /// A default priority to be used for testing purposes.
    /// </summary>
    public const WorkItemPriority Priority = WorkItemPriority.Low;
    
    /// <summary>
    /// A default type to be used for testing purposes.
    /// </summary>
    public const WorkItemType Type = WorkItemType.Task;
    
    public static List<WorkItem> DefaultWorkItems =>
    [
        WorkItem.Create(),
        WorkItem.Create(),
        WorkItem.Create()
    ];

    public static List<Id<Documentation>> DefaultDocumentations =>
    [
        Id<Documentation>.Create(),
        Id<Documentation>.Create(),
        Id<Documentation>.Create()
    ];
}