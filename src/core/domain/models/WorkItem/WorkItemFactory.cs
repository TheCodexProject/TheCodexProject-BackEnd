using System.Reflection;
using domain.models.Users;
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

    /// <summary>
    /// Adds a description to the WorkItem
    /// </summary>
    /// <param name="description">Description to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public WorkItemFactory WithDescription(string description)
    {
        // Get WorkItemDescription private constructor and instantiate a new WorkItemDescription
        var workItemDescriptionConstructor = typeof(WorkItemDescription)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(string)}, null);
        if (workItemDescriptionConstructor == null) throw new NullReferenceException("WorkItemDescription constructor not found");
        
        var workItemDescription = (WorkItemDescription) workItemDescriptionConstructor.Invoke(new object[] {description});
        
        // Get the Description property of the WorkItem class and set the value
        const string property = "Description";
        
        var descriptionProperty = typeof(WorkItem).GetProperty(property);
        if (descriptionProperty == null) throw new NullReferenceException($"{property} property not found");
        
        // Set the value of the property
        descriptionProperty.SetValue(_workItem, workItemDescription);
        return this;
    }
    
    /// <summary>
    /// Adds a status to the WorkItem
    /// </summary>
    /// <param name="status">Status to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public WorkItemFactory WithStatus(WorkItemStatus status)
    {
        // Get the Status property of the WorkItem class and set the value
        const string property = "Status";
        
        var statusProperty = typeof(WorkItem).GetProperty(property);
        if (statusProperty == null) throw new NullReferenceException($"{property} property not found");
        
        // Set the value of the property
        statusProperty.SetValue(_workItem, status);
        return this;
    }
    
    /// <summary>
    /// Adds a priority to the WorkItem
    /// </summary>
    /// <param name="priority">Priority to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public WorkItemFactory WithPriority(WorkItemPriority priority)
    {
        // Get the Priority property of the WorkItem class and set the value
        const string property = "Priority";
        
        var priorityProperty = typeof(WorkItem).GetProperty(property);
        if (priorityProperty == null) throw new NullReferenceException($"{property} property not found");
        
        // Set the value of the property
        priorityProperty.SetValue(_workItem, priority);
        return this;
    }
    
    /// <summary>
    /// Adds a type to the WorkItem
    /// </summary>
    /// <param name="type">Type to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public WorkItemFactory WithType(WorkItemType type)
    {
        // Get the Type property of the WorkItem class and set the value
        const string property = "Type";
        
        var typeProperty = typeof(WorkItem).GetProperty(property);
        if (typeProperty == null) throw new NullReferenceException($"{property} property not found");
        
        // Set the value of the property
        typeProperty.SetValue(_workItem, type);
        return this;
    }
    
    /// <summary>
    /// Returns the built WorkItem
    /// </summary>
    /// <returns>A <see cref="WorkItem"/> with a set of values.</returns>
    public WorkItem Build()
    {
        return _workItem;
    }
}