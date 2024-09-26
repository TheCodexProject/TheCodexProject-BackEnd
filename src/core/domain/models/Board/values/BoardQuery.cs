using domain.exceptions.board.boardQuery;
using domain.models.workItem;
using OperationResult;


namespace domain.models.board.values;

public class BoardQuery
{
    /// <summary>
    /// Holds the complete IQueryable query for WorkItems.
    /// </summary>
    public IQueryable<WorkItem> Query { get; private set; }

    /// <summary>
    /// Private constructor for the <see cref="BoardQuery"/> class.
    /// </summary>
    private BoardQuery() { }

    /// <summary>
    /// The constructor for the <see cref="BoardQuery"/> class.
    /// </summary>
    /// <param name="query">The query for WorkItems.</param>
    private BoardQuery(IQueryable<WorkItem> query)
    {
        Query = query;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="BoardQuery"/> class.
    /// </summary>
    /// <param name="query">The IQueryable query.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<BoardQuery> Create(IQueryable<WorkItem> query)
    {
        var result = Validate(query);

        if (result.IsFailure)
        {
            return Result<BoardQuery>.Failure(result.Errors.ToArray());
        }

        var boardQuery = new BoardQuery(query);
        return boardQuery;
    }

    /// <summary>
    /// Validates the board query.
    /// </summary>
    /// <param name="query">The query to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(IQueryable<WorkItem> query)
    {
        var errors = new List<Exception>();

        if (query == null)
        {
            errors.Add(new BoardQueryNullException());
            return Result.Failure(errors.ToArray());
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Executes the query and returns the result as a list of WorkItems.
    /// </summary>
    /// <returns>A IEnumerable of WorkItems.</returns>
    public IEnumerable<WorkItem> Execute()
    {
        return Query.ToList();
    }

    /// <summary>
    /// Equality operator for the <see cref="BoardQuery"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is BoardQuery query)
        {
            return query.Query.Expression.ToString() == Query.Expression.ToString();
        }

        return false;
    }
}
