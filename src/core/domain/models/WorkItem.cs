namespace domain.models;

public class WorkItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
    
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Type { get; set; }
    public string Assignee { get; set; }
}