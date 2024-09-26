

using domain.models.workItem;


namespace domain.models.board;

public static class BoardConstants
{
    /// <summary>
    /// A default title to be used for testing purposes.
    /// </summary>
    public const string DefaultTitle = "Untitled Board";

    /// <summary>
    /// Provides a default query by generating a set of default WorkItems using the WorkItemBuilder.
    /// </summary>
    /// <returns>An IQueryable representing the default query for WorkItems.</returns>
    public static IQueryable<WorkItem> DefaultQuery()
    {
        // Generate default WorkItems using WorkItemBuilder's MakeDefault method
        var defaultWorkItems = new List<WorkItem>();

        // Assume we want to create 10 default WorkItems using the WorkItemBuilder
        for (int i = 0; i < 10; i++)
        {
            var workItemResult = WorkItemBuilder.Create().MakeDefault();

            if (workItemResult.IsSuccess)
            {
                defaultWorkItems.Add(workItemResult.Value);
            }
            else
            {
                // Handle errors if needed (e.g., logging)
            }
        }

        // Convert the list to IQueryable and return
        return defaultWorkItems.AsQueryable();
    }
}
