using domain.models.workItem;
using domain.models.workItem.values;

namespace Unit.models.WorkItem;

public class WorkItemBuilderTests
{
    // MakeDefault - Ensure the builder creates a default work with default values.
    [Fact]
    public void WorkItemBuilder_Makes_Default_WorkItem_Successfully()
    {
        // Arrange
        var builder = WorkItemBuilder.Create();
        
        // Act
        var result = builder.MakeDefault();
        
        // Assert
        Assert.True(result.IsSuccess);
    }
    
    // Chaining - Ensure the builder can chain methods together.
    [Fact]
    public void WorkItemBuilder_Chains_Methods_Successfully()
    {
        // Arrange
        var builder = WorkItemBuilder.Create();
        
        // Act
        var result = builder
            .WithTitle("Title")
            .WithDescription("Description")
            .WithStatus(WorkItemStatus.NotStarted)
            .WithPriority(WorkItemPriority.Low)
            .WithType(WorkItemType.Task)
            .Build();
        
        // Assert
        Assert.True(result.IsSuccess);
    }
    
    // Optional Fields - Ensure the builder can build the work item without optional fields. (Any field except title)
    [Fact]
    public void WorkItemBuilder_Builds_Without_Optional_Fields_Successfully()
    {
        // Arrange
        var builder = WorkItemBuilder.Create();
        
        // Act
        var result = builder
            .WithTitle("Title")
            .Build();
        
        // Assert
        Assert.True(result.IsSuccess);
    }
    
    // Empty Required Fields - Ensure the builder cannot build the work item with empty required fields. (Title)
    [Fact]
    public void WorkItemBuilder_Builds_With_Empty_Required_Fields_Successfully()
    {
        // Arrange
        var builder = WorkItemBuilder.Create();
        
        // Act
        var result = builder
            .WithTitle("")
            .Build();
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    // Null Required Fields - Ensure the builder cannot build the work item with null required fields. (Title)
    [Fact]
    public void WorkItemBuilder_Builds_With_Null_Required_Fields_Successfully()
    {
        // Arrange
        var builder = WorkItemBuilder.Create();
        
        // Act
        var result = builder
            .WithTitle(null)
            .Build();
        
        // Assert
        Assert.True(result.IsFailure);
    }
    
    // Multiple Errors - Ensure the builder can return multiple errors when building the work item.
    [Fact]
    public void WorkItemBuilder_Returns_Multiple_Errors_Successfully()
    {
        // Arrange
        var builder = WorkItemBuilder.Create();
        var description = new string('a', 1001);
        
        // Act
        var result = builder
            .WithTitle("")
            .WithDescription(description)
            .Build();
        
        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(2, result.Errors.Count());
    }
}