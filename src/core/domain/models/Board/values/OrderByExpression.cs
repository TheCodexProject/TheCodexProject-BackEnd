using domain.exceptions.board.orderByExpression;
using domain.models.workItem;
using OperationResult;
using System.Linq.Expressions;

namespace domain.models.board.values;

public class OrderByExpression
{
    public Expression<Func<WorkItem, object>> Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private OrderByExpression() { }

    /// <summary>
    /// The private constructor for the <see cref="OrderByExpression"/> class.
    /// </summary>
    /// <param name="value">The order by expression.</param>
    private OrderByExpression(Expression<Func<WorkItem, object>> value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="OrderByExpression"/> class.
    /// </summary>
    /// <param name="expression">The order by expression to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<OrderByExpression> Create(Expression<Func<WorkItem, object>> expression)
    {
        var result = Validate(expression);

        if (result.IsFailure)
        {
            return Result<OrderByExpression>.Failure(result.Errors.ToArray());
        }

        var orderByExpression = new OrderByExpression(expression);
        return orderByExpression;
    }

    /// <summary>
    /// Validates the order by expression.
    /// </summary>
    /// <param name="expression">The order by expression to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(Expression<Func<WorkItem, object>> expression)
    {
        var errors = new List<Exception>();

        if (expression == null)
        {
            errors.Add(new OrderByExpressionNullException());
            return Result.Failure(errors.ToArray());
        }

        return Result.Success();
    }

    /// <summary>
    /// Implicit conversion from <see cref="OrderByExpression"/> to <see cref="Expression{Func{WorkItem, object}}"/>
    /// </summary>
    /// <param name="orderByExpression">The order by expression itself.</param>
    /// <returns>The inner value of the <see cref="OrderByExpression"/> object.</returns>
    public static implicit operator Expression<Func<WorkItem, object>>(OrderByExpression orderByExpression) => orderByExpression.Value;

    /// <summary>
    /// Equality operator for the <see cref="OrderByExpression"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is OrderByExpression expression)
        {
            return expression.Value.ToString() == Value.ToString();
        }

        return false;
    }
}
