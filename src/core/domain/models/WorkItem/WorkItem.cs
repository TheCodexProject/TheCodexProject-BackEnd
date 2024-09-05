using domain.models.Users;
using domain.models.workItem.values;


namespace domain.models.workItem;

public class WorkItem
{
    public Guid Id { get; set; }
    public WorkItemTitle Title { get; set; }
    public WorkItemDescription Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
    
    public WorkItemStatus Status { get; set; }
    public WorkItemPriority Priority { get; set; }
    public WorkItemType Type { get; set; }
    public User Assignee { get; set; }
}