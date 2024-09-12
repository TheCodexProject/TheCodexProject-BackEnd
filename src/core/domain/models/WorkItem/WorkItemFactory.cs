using System.Reflection;
using domain.models.workItem.values;

namespace domain.models.workItem;

/// <summary>
/// The WorkItemFactory can be used to create different types of "Template" WorkItems.
/// Used primarily for testing purposes.
/// </summary>
public class WorkItemFactory
{
    /// <summary>
    /// The WorkItem that is being created.
    /// </summary>
    private readonly WorkItem _workItem = WorkItem.Create();
    
    /// <summary>
    /// Initializes the creation of a new <see cref="WorkItem"/>
    /// </summary>
    /// <returns></returns>
    public static WorkItemFactory Create()
    {
        return new WorkItemFactory();
    }

    // ! NOTE: THE FOLLOWING METHODS CAN CREATE INVALID STATES FOR WORK ITEM, SINCE IT USES REFLECTION TO SET VALUES DIRECTLY
    // ! WHICH MEANS THAT IT CAN BYPASS THE VALIDATION RULES OF THE WORK ITEM CLASS
    // ! 🔴 ONLY USE THIS FOR TESTING PURPOSES 🔴
    
    /// <summary>
    /// Adds a title to the WorkItem
    /// </summary>
    /// <param name="title">Title to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public WorkItemFactory WithTitle(string title)
    {
        // Get WorkItemTitle private constructor and instantiate a new WorkItemTitle
        var workItemTitleConstructor = typeof(WorkItemTitle)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(string)}, null);
        if (workItemTitleConstructor == null) throw new NullReferenceException("WorkItemTitle constructor not found");
        
        var workItemTitle = (WorkItemTitle) workItemTitleConstructor.Invoke(new object[] {title});
        
        // Get the Title property of the WorkItem class and set the value
        const string property = "Title";
        
        var titleProperty = typeof(WorkItem).GetProperty(property);
        if (titleProperty == null) throw new NullReferenceException($"{property} property not found");
        
        // Set the value of the property
        titleProperty.SetValue(_workItem, workItemTitle);
        return this;
    }
}