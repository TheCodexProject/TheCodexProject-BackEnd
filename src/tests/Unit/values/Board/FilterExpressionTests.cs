using domain.exceptions.board.filterExpression;
using domain.models.board.values;
using domain.models.workItem;
using domain.models.workItem.values;
using System.Linq.Expressions;

namespace Unit.values.boardTest;

public class FilterExpressionTests
{
    /// <summary>
    /// Test to check if FilterExpression value object will fail with a null expression.
    /// </summary>
    [Fact]
    public void Filter_Cannot_Be_Null_Is_Failure()
    {
        // Arrange
        Expression<Func<WorkItem, bool>> expression = null;

        // Act
        var result = FilterExpression.Create(expression);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct exception for null expressions.
    /// </summary>
    [Fact]
    public void Filter_Cannot_Be_Null_Exception_Check()
    {
        // Arrange
        Expression<Func<WorkItem, bool>> expression = null;

        // Act
        var result = FilterExpression.Create(expression);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is FilterExpressionNullException);
    }

    /// <summary>
    /// Test to ensure that a valid expression can be created.
    /// </summary>
    [Fact]
    public void Filter_Can_Be_Created_With_Valid_Expression()
    {
        // Arrange
        Expression<Func<WorkItem, bool>> expression = w => w.Priority == WorkItemPriority.Low;

        // Act
        var result = FilterExpression.Create(expression);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expression, result.Value.Value);
    }

    /// <summary>
    /// Test to ensure that FilterExpression equality check works as expected.
    /// </summary>
    [Fact]
    public void Filter_Equality_Check_Works()
    {
        // Arrange
        Expression<Func<WorkItem, bool>> expression1 = w => w.Priority == WorkItemPriority.Low;
        Expression<Func<WorkItem, bool>> expression2 = w => w.Priority == WorkItemPriority.Low;

        var filter1 = FilterExpression.Create(expression1).Value;
        var filter2 = FilterExpression.Create(expression2).Value;

        // Act & Assert
        Assert.True(filter1.Equals(filter2));
    }

    /// <summary>
    /// Test to ensure that FilterExpression equality check works with different expressions.
    /// </summary>
    [Fact]
    public void Filter_Equality_Check_With_Different_Expressions_Fails()
    {
        // Arrange
        Expression<Func<WorkItem, bool>> expression1 = w => w.Priority == WorkItemPriority.Low;
        Expression<Func<WorkItem, bool>> expression2 = w => w.Status == WorkItemStatus.InProgress;

        var filter1 = FilterExpression.Create(expression1).Value;
        var filter2 = FilterExpression.Create(expression2).Value;

        // Act & Assert
        Assert.False(filter1.Equals(filter2));
    }
}
