using domain.models.board.values;
using domain.models.shared;
using domain.models.workItem;
using OperationResult;
using System.Linq;

namespace domain.models.board
{
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
        /// Holds the board query, which is an IQueryable query for WorkItems.
        /// </summary>
        public BoardQuery? Query { get; private set; }

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
        /// Sets the query for the board using an IQueryable of WorkItems.
        /// This query can be used with Entity Framework Core.
        /// </summary>
        /// <param name="query">The query to be set.</param>
        public Result UpdateQuery(IQueryable<WorkItem> query)
        {
            var result = BoardQuery.Create(query);

            if (result.IsFailure)
            {
                return Result.Failure(result.Errors.ToArray());
            }

            Query = result.Value;
            return Result.Success();
        }

        /// <summary>
        /// Executes the query stored in the board and returns the list of filtered WorkItems.
        /// </summary>
        /// <returns>A IEnumerable of WorkItems.</returns>
        public IEnumerable<WorkItem> ExecuteQuery()
        {
            return Query.Execute();
        }
    }
}
