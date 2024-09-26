using domain.exceptions.board.boardQuery;
using domain.models.board.values;
using domain.models.workItem;

namespace Unit.values.board;

public class BoardQueryTests
{
    /// <summary>
    /// Test to check if BoardQuery value object will fail to create when a null query is passed.
    /// </summary>
    [Fact]
    public void Query_Cannot_Be_Null_Is_Failure()
    {
        // Arrange
        IQueryable<WorkItem> query = null;

        // Act
        var result = BoardQuery.Create(query);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct exception for null query.
    /// </summary>
    [Fact]
    public void Query_Cannot_Be_Null_Exception_Check()
    {
        // Arrange
        IQueryable<WorkItem> query = null;

        // Act
        var result = BoardQuery.Create(query);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is BoardQueryNullException);
    }

    /// <summary>
    /// Test to check that a valid query can be created successfully.
    /// </summary>
    [Fact]
    public void Query_Can_Be_Created_With_Valid_IQueryable()
    {
        // Arrange
        IQueryable<WorkItem> workItems = new List<WorkItem>
            {
                new WorkItemBuilder().MakeDefault().Value,  // Create default work items using the builder
                new WorkItemBuilder().MakeDefault().Value
            }.AsQueryable();

        // Act
        var result = BoardQuery.Create(workItems);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(workItems, result.Value.Query); // Ensure the query is stored correctly
    }

    /// <summary>
    /// Test to check that executing the query returns the correct WorkItems.
    /// </summary>
    [Fact]
    public void Query_Executes_Correctly_With_Valid_WorkItems()
    {
        // Arrange
        var workItems = new List<WorkItem>
            {
                new WorkItemBuilder().MakeDefault().Value,
                new WorkItemBuilder().MakeDefault().Value
            }.AsQueryable();

        var result = BoardQuery.Create(workItems);

        // Act
        var executedItems = result.Value.Execute().ToList();

        // Assert
        Assert.Equal(2, executedItems.Count);  // Ensure the correct number of items are returned
    }

    /// <summary>
    /// Test to check that an empty query still works.
    /// </summary>
    [Fact]
    public void Query_Executes_Correctly_With_Empty_WorkItems()
    {
        // Arrange
        var workItems = new List<WorkItem>().AsQueryable(); // Empty list
        var result = BoardQuery.Create(workItems);

        // Act
        var executedItems = result.Value.Execute().ToList();

        // Assert
        Assert.Empty(executedItems); // Expecting an empty result
    }

    /// <summary>
    /// Test to ensure that two BoardQuery objects with the same expression are equal.
    /// </summary>
    [Fact]
    public void Query_Equality_Check()
    {
        // Arrange
        var workItems1 = new List<WorkItem>
            {
                new WorkItemBuilder().MakeDefault().Value
            }.AsQueryable();

        var workItems2 = new List<WorkItem>
            {
                new WorkItemBuilder().MakeDefault().Value
            }.AsQueryable();

        var boardQuery1 = BoardQuery.Create(workItems1).Value;
        var boardQuery2 = BoardQuery.Create(workItems2).Value;

        // Act & Assert
        Assert.True(boardQuery1.Equals(boardQuery2));
    }
}