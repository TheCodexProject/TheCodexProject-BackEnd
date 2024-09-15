


using domain.models.Workspace.values;

namespace domain.models.Workspace;
public class Workspace
{
    // Does this need to inculde groups
    public Guid Id { get; set; }

    public WorkspaceTitle Title { get; set; }

    // Todo add Project / items here 
    // public List<Project> Projects { get; set; }
}

