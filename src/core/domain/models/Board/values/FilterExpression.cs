using domain.exceptions.board.filterExpression;
using domain.models.workItem;
using OperationResult;
using System.Linq.Expressions;

namespace domain.models.board.values;

public class FilterExpression
{
    public Expression<Func<WorkItem, bool>> Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private FilterExpression() { }

    /// <summary>
    /// The private constructor for the <see cref="FilterExpression"/> class.
    /// </summary>
    /// <param name="value">The filter expression.</param>
    private FilterExpression(Expression<Func<WorkItem, bool>> value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="FilterExpression"/> class.
    /// </summary>
    /// <param name="expression">The filter expression to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<FilterExpression> Create(Expression<Func<WorkItem, bool>> expression)
    {
        var result = Validate(expression);

        if (result.IsFailure)
        {
            return Result<FilterExpression>.Failure(result.Errors.ToArray());
        }

        var filterExpression = new FilterExpression(expression);
        return filterExpression;
    }

    /// <summary>
    /// Validates the filter expression.
    /// </summary>
    /// <param name="expression">The filter expression to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(Expression<Func<WorkItem, bool>> expression)
    {
        var errors = new List<Exception>();

        if (expression == null)
        {
            errors.Add(new FilterExpressionNullException());
            return Result.Failure(errors.ToArray());
        }

        return Result.Success();
    }

    /// <summary>
    /// Implicit conversion from <see cref="FilterExpression"/> to <see cref="Expression{Func{WorkItem, bool}}"/>
    /// </summary>
    /// <param name="filterExpression">The filter expression itself.</param>
    /// <returns>The inner value of the <see cref="FilterExpression"/> object.</returns>
    public static implicit operator Expression<Func<WorkItem, bool>>(FilterExpression filterExpression) => filterExpression.Value;

    /// <summary>
    /// Equality operator for the <see cref="FilterExpression"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is FilterExpression expression)
        {
            return expression.Value.ToString() == Value.ToString();
        }

        return false;
    }
}
