using domain.models.Project.values;
using domain.models.Users;

namespace domain.models.Project;

public class Project
{
    public Guid Id { get; set; }

    public ProjectTitle ProjectTitle { get; set; }

    public ProjectDescription ProjectDescription { get; set; }

    public ProjectTimeRange StartAndEndTime { get; set; } // Both start and end time. They can both respectively be accessed through their getters.
    
    public ProjectMethodology ProjectMethodology { get; set; }

    public ProjectStatus Status { get; set; }

    public ProjectPriority Priority { get; set; }

    public User Assignee { get; set; }
}