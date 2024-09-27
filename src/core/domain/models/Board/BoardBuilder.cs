using domain.exceptions;
using domain.exceptions.board.boardTitle;
using domain.interfaces;
using OperationResult;

namespace domain.models.board;

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
    /// Adds a title to the board being built.
    /// </summary>
    /// <param name="title">The title to set.</param>
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
    /// Builds the <see cref="Board"/> instance.
    /// </summary>
    public Result<Board> Build()
    {
        // Required fields validation: Ensure the title is present.
        if (_errors.Any(e => e is BoardTitleEmptyException))
        {
            var error = _errors.First(e => e is BoardTitleEmptyException);
            _errors.Remove(error);

            var requiredFieldMissingException = new RequiredFieldMissingException("Title is required.", error);
            _errors.Insert(0, requiredFieldMissingException);
        }
        else if (_board.Title == null)
        {
            _errors.Add(new RequiredFieldMissingException("Title is required", new BoardTitleEmptyException()));
        }

        return _errors.Any() ? Result<Board>.Failure(_errors.ToArray()) : Result<Board>.Success(_board);
    }

    /// <summary>
    /// Builds the <see cref="Board"/> with default values.
    /// </summary>
    public Result<Board> MakeDefault()
    {
        return new BoardBuilder()
            .WithTitle(BoardConstants.DefaultTitle)
            .Build();
    }
}
