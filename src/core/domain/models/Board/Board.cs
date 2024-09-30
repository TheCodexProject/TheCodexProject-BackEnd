using domain.models.board.values;
using domain.models.shared;
using domain.models.workItem;
using OperationResult;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using domain.exceptions.board;
using domain.exceptions.Board;

namespace domain.models.board;

public class Board
{
    /// <summary>
    /// The unique identifier for the Board.
    /// </summary>
    public Id<Board> Id { get; private set; }

    /// <summary>
    /// Holds the title of the Board.
    /// </summary>
    public BoardTitle? Title { get; private set; }

    /// <summary>
    /// Holds a private list of filter expressions used to filter WorkItems.
    /// </summary>
    private readonly List<FilterExpression> _filters = new List<FilterExpression>();

    /// <summary>
    /// Holds a private list of order-by expressions used to sort WorkItems.
    /// </summary>
    private readonly List<OrderByExpression> _orderByExpressions = new List<OrderByExpression>();

    /// <summary>
    /// Exposes a read-only view of filter expressions.
    /// </summary>
    public ReadOnlyCollection<FilterExpression> Filters => _filters.AsReadOnly();

    /// <summary>
    /// Exposes a read-only view of order-by expressions.
    /// </summary>
    public ReadOnlyCollection<OrderByExpression> OrderByExpressions => _orderByExpressions.AsReadOnly();

    /// <summary>
    /// Creates a new instance of <see cref="Board"/> with default values.
    /// </summary>
    private Board()
    {
        Id = Id<Board>.Create();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Board"/> with default values.
    /// </summary>
    /// <returns>A <see cref="Board"/></returns>
    public static Board Create()
    {
        return new Board();
    }

    /// <summary>
    /// Updates the title of the Board.
    /// </summary>
    /// <param name="title">The new title.</param>
    /// <returns>A <see cref="Result"/> indicating if the update was a success.</returns>
    public Result UpdateTitle(string title)
    {
        var newTitle = BoardTitle.Create(title);

        if (newTitle.IsFailure)
        {
            // Return the errors from the result.
            return Result.Failure(newTitle.Errors.ToArray());
        }

        // Update the title.
        Title = newTitle.Value;

        return Result.Success();
    }

    /// <summary>
    /// Adds a filter expression to the board.
    /// </summary>
    /// <param name="filterExpression">The filter expression to add.</param>
    public Result AddFilter(Expression<Func<WorkItem, bool>> filterExpression)
    {
        var result = FilterExpression.Create(filterExpression);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        _filters.Add(result.Value);
        return Result.Success();
    }

    /// <summary>
    /// Removes a filter expression from the board.
    /// </summary>
    /// <param name="filterExpression">The filter expression to remove.</param>
    public Result RemoveFilter(FilterExpression filterExpression)
    {
        if (_filters.Contains(filterExpression))
        {
            // Filter not found, return failure.
            return Result.Failure(new BoardFilterNotFoundException());
        }

        _filters.Remove(filterExpression);
        return Result.Success();
    }


    /// <summary>
    /// Adds an order-by expression to the board.
    /// </summary>
    /// <param name="orderByExpression">The order-by expression to add.</param>
    public Result AddOrderBy(Expression<Func<WorkItem, object>> orderByExpression)
    {
        var result = OrderByExpression.Create(orderByExpression);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        _orderByExpressions.Add(result.Value);
        return Result.Success();
    }

    /// <summary>
    /// Removes an order-by expression from the board.
    /// </summary>
    /// <param name="orderByExpression">The order-by expression to remove.</param>
    public Result RemoveOrderBy(OrderByExpression orderByExpression)
    {

        if (_orderByExpressions.Contains(orderByExpression))
        {
            // OrderBy expression not found, return failure.
            return Result.Failure(new BoardOrderByNotFoundException());
        }

        _orderByExpressions.Remove(orderByExpression);
        return Result.Success();
    }
}
