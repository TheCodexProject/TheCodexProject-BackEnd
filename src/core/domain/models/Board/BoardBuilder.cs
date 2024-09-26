using domain.exceptions;
using domain.exceptions.board.boardTitle;
using domain.exceptions.board.boardQuery;
using domain.interfaces;
using OperationResult;
using System.Collections.Generic;
using System.Linq;
using domain.models.workItem;

namespace domain.models.board
{
    public class BoardBuilder : IBuilder<Board>
    {
        private readonly Board _board = Board.Create();
        private readonly List<Exception> _errors = new();

        /// <summary>
        /// The private constructor for the <see cref="BoardBuilder"/> class.
        /// </summary>
        private BoardBuilder() { }

        /// <summary>
        /// Factory method to create a new instance of the <see cref="BoardBuilder"/> class.
        /// </summary>
        /// <returns>A <see cref="BoardBuilder"/></returns>
        public static BoardBuilder Create()
        {
            return new BoardBuilder();
        }

        /// <summary>
        /// Function to add title to the build of <see cref="BoardBuilder"/>.
        /// </summary>
        /// <param name="title">Title to use.</param>
        public BoardBuilder WithTitle(string title)
        {
            var result = _board.UpdateTitle(title);

            if (result.IsFailure)
            {
                _errors.AddRange(result.Errors);
            }

            return this;
        }

        /// <summary>
        /// Function to add query to the build of <see cref="BoardBuilder"/>.
        /// </summary>
        /// <param name="query">Query to use.</param>
        public BoardBuilder WithQuery(IQueryable<WorkItem> query)
        {
            var result = _board.UpdateQuery(query);

            if (result.IsFailure)
            {
                _errors.AddRange(result.Errors);
            }

            return this;
        }

        /// <summary>
        /// Function to build the <see cref="Board"/>.
        /// </summary>
        public Result<Board> Build()
        {
            // Required fields validation
            if (_errors.Any(e => e is BoardTitleEmptyException))
            {
                var error = _errors.First(e => e is BoardTitleEmptyException);
                _errors.Remove(error);

                var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
                _errors.Insert(0, requiredFieldMissingException);
            }
            else
            {
                if (_board.Title == null)
                {
                    _errors.Add(new RequiredFieldMissingException("Title is required", new BoardTitleEmptyException()));
                }
            }

            // Validate the query field
            if (_board.Query == null)
            {
                _errors.Add(new RequiredFieldMissingException("Query is required", new BoardQueryNullException()));
            }

            return _errors.Any() ? Result<Board>.Failure(_errors.ToArray()) : _board;
        }

        /// <summary>
        /// Function to build with default values <see cref="Board"/>.
        /// </summary>
        public Result<Board> MakeDefault()
        {
            return new BoardBuilder().WithTitle(BoardConstants.DefaultTitle).WithQuery(BoardConstants.DefaultQuery()).Build();
        }
    }
}
