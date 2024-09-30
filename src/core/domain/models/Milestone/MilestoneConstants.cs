using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.models.workItem;

namespace domain.models.milestone;

public class MilestoneConstants
{
    /// <summary>
    /// A default title to be used for testing purposes.
    /// </summary>
    public static readonly String DefaultTitle = "No title";
    
    public static readonly List<WorkItem> DefaultWorkItems 
        = new List<WorkItem>
        {
            WorkItemBuilder.Create().MakeDefault(),
            WorkItemBuilder.Create().MakeDefault()
        };
}