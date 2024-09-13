using domain.models.workItem;
using domain.models.workItem.values;

namespace Unit.common.factories;

public class WorkItemFactoryTests
{

    /// <summary>
    /// Test to see that Empty WorkItem is created with default values. (Title)
    /// </summary>
    [Fact]
    public void Create_Empty_WorkItem_Should_Have_Default_Values_Title()
    {
        // Arrange
        var title = WorkItemConstants.DefaultTitle;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .Build();
        
        var result = workitem.Title;
        
        // Assert
        Assert.Equal(result, title);
    }
    
    /// <summary>
    /// Test to see that Empty WorkItem is created with default values. (Description)
    /// </summary>
    [Fact]
    public void Create_Empty_WorkItem_Should_Have_Default_Values_Description()
    {
        // Arrange
        var description = WorkItemConstants.DefaultDescription;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .Build();
        
        var result = workitem.Description;
        
        // Assert
        Assert.Equal(result, description);
    }
    
    /// <summary>
    /// Test to see that Empty WorkItem is created with default values. (Status)
    /// </summary>
    [Fact]
    public void Create_Empty_WorkItem_Should_Have_Default_Values_Status()
    {
        // Arrange
        var status = WorkItemConstants.DefaultStatus;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .Build();
        
        var result = workitem.Status;
        
        // Assert
        Assert.Equal(result, status);
    }
    
    /// <summary>
    /// Test to see that Empty WorkItem is created with default values. (Priority)
    /// </summary>
    [Fact]
    public void Create_Empty_WorkItem_Should_Have_Default_Values_Priority()
    {
        // Arrange
        var priority = WorkItemConstants.DefaultPriority;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .Build();
        
        var result = workitem.Priority;
        
        // Assert
        Assert.Equal(result, priority);
    }
    
    [Fact]
    public void Create_Empty_WorkItem_Should_Have_Default_Values_Type()
    {
        // Arrange
        var type = WorkItemConstants.DefaultType;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .Build();
        
        var result = workitem.Type;
        
        // Assert
        Assert.Equal(result, type);
    }
    
    [Fact]
    public void Create_WorkItem_With_Title_Should_Have_Title()
    {
        // Arrange
        var title = "Test Title";
        
        // Act
        var workitem = WorkItemFactory.Create()
            .WithTitle(title)
            .Build();
        
        var result = workitem.Title;
        
        // Assert
        Assert.Equal(result, title);
    }
    
    [Fact]
    public void Create_WorkItem_With_Description_Should_Have_Description()
    {
        // Arrange
        var description = "Test Description";
        
        // Act
        var workitem = WorkItemFactory.Create()
            .WithDescription(description)
            .Build();
        
        var result = workitem.Description;
        
        // Assert
        Assert.Equal(result, description);
    }
    
    [Fact]
    public void Create_WorkItem_With_Status_Should_Have_Status()
    {
        // Arrange
        var status = WorkItemStatus.InProgress;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .WithStatus(status)
            .Build();
        
        var result = workitem.Status;
        
        // Assert
        Assert.Equal(result, status);
    }
    
    [Fact]
    public void Create_WorkItem_With_Priority_Should_Have_Priority()
    {
        // Arrange
        var priority = WorkItemPriority.High;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .WithPriority(priority)
            .Build();
        
        var result = workitem.Priority;
        
        // Assert
        Assert.Equal(result, priority);
    }
    
    [Fact]
    public void Create_WorkItem_With_Type_Should_Have_Type()
    {
        // Arrange
        var type = WorkItemType.Task;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .WithType(type)
            .Build();
        
        var result = workitem.Type;
        
        // Assert
        Assert.Equal(result, type);
    }

    [Fact]
    public void Create_WorkItem_With_Multiple_Changes_Should_Match()
    {
        // Arrange
        var title = "Test Title";
        var description = "Test Description";
        var status = WorkItemStatus.InProgress;
        var priority = WorkItemPriority.High;
        var type = WorkItemType.Bug;
        
        // Act
        var workitem = WorkItemFactory.Create()
            .WithTitle(title)
            .WithDescription(description)
            .WithStatus(status)
            .WithPriority(priority)
            .WithType(type)
            .Build();
        
        // Assert
        Assert.Equal(workitem.Title, title);
        Assert.Equal(workitem.Description, description);
        Assert.Equal(workitem.Status, status);
        Assert.Equal(workitem.Priority, priority);
        Assert.Equal(workitem.Type, type);
    }
}