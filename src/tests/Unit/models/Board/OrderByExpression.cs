using domain.exceptions.board.orderByExpression;
using domain.models.board.values;
using domain.models.workItem;
using System.Linq.Expressions;

namespace Unit.values.boardTest;

public class OrderByExpressionTests
{
    /// <summary>
    /// Test to check if OrderByExpression value object will fail with a null expression.
    /// </summary>
    [Fact]
    public void OrderBy_Cannot_Be_Null_Is_Failure()
    {
        // Arrange
        Expression<Func<WorkItem, object>> expression = null;

        // Act
        var result = OrderByExpression.Create(expression);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that it hands the user the correct exception for null expressions.
    /// </summary>
    [Fact]
    public void OrderBy_Cannot_Be_Null_Exception_Check()
    {
        // Arrange
        Expression<Func<WorkItem, object>> expression = null;

        // Act
        var result = OrderByExpression.Create(expression);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is OrderByExpressionNullException);
    }

    /// <summary>
    /// Test to ensure that a valid expression can be created.
    /// </summary>
    [Fact]
    public void OrderBy_Can_Be_Created_With_Valid_Expression()
    {
        // Arrange
        Expression<Func<WorkItem, object>> expression = w => w.Priority;

        // Act
        var result = OrderByExpression.Create(expression);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expression, result.Value.Value);
    }

    /// <summary>
    /// Test to ensure that OrderByExpression equality check works as expected.
    /// </summary>
    [Fact]
    public void OrderBy_Equality_Check_Works()
    {
        // Arrange
        Expression<Func<WorkItem, object>> expression1 = w => w.Priority;
        Expression<Func<WorkItem, object>> expression2 = w => w.Priority;

        var orderBy1 = OrderByExpression.Create(expression1).Value;
        var orderBy2 = OrderByExpression.Create(expression2).Value;

        // Act & Assert
        Assert.True(orderBy1.Equals(orderBy2));
    }

    /// <summary>
    /// Test to ensure that OrderByExpression equality check works with different expressions.
    /// </summary>
    [Fact]
    public void OrderBy_Equality_Check_With_Different_Expressions_Fails()
    {
        // Arrange
        Expression<Func<WorkItem, object>> expression1 = w => w.Priority;
        Expression<Func<WorkItem, object>> expression2 = w => w.Title;

        var orderBy1 = OrderByExpression.Create(expression1).Value;
        var orderBy2 = OrderByExpression.Create(expression2).Value;

        // Act & Assert
        Assert.False(orderBy1.Equals(orderBy2));
    }
}
