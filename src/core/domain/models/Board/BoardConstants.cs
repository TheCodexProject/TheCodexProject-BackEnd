using domain.models.workItem;
using domain.models.workItem.values;
using System.Linq.Expressions;

namespace domain.models.board;

public static class BoardConstants
{
    /// <summary>
    /// A default title to be used for testing purposes.
    /// </summary>
    public const string DefaultTitle = "Untitled Board";

    /// <summary>
    /// A list of example filters used for testing.
    /// </summary>
    public static readonly List<Expression<Func<WorkItem, bool>>> ExampleFilters = new()
    {
        workItem => workItem.Priority == WorkItemPriority.High,
    };

    /// <summary>
    /// A list of example order-by expressions used for testing.
    /// </summary>
    public static readonly List<Expression<Func<WorkItem, object>>> ExampleOrderBys = new()
    {
        workItem => workItem.Priority,
        workItem => workItem.Status,
    };
}
