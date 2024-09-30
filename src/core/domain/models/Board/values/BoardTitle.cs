using domain.exceptions.board.boardTitle;
using OperationResult;

namespace domain.models.board.values;

public class BoardTitle
{
    public string Value { get; }

    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private BoardTitle() { }

    /// <summary>
    /// The private constructor for the <see cref="BoardTitle"/> class.
    /// </summary>
    /// <param name="value"></param>
    private BoardTitle(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create a new instance of the <see cref="BoardTitle"/> class.
    /// </summary>
    /// <param name="value">Title to use.</param>
    /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<BoardTitle> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<BoardTitle>.Failure(result.Errors.ToArray());
        }

        var boardTitle = new BoardTitle(value);
        return boardTitle;
    }

    /// <summary>
    /// Validates the board title.
    /// </summary>
    /// <param name="value">Title to be validated.</param>
    /// <returns> A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new BoardTitleEmptyException());
            return Result.Failure(errors.ToArray());
        }

        switch (value)
        {
            case { Length: < 3 }:
                errors.Add(new BoardTitleTooShortException());
                break;
            case { Length: > 75 }:
                errors.Add(new BoardTitleTooLongException());
                break;
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }

    /// <summary>
    /// Implicit conversion from <see cref="BoardTitle"/> to <see cref="string"/>
    /// </summary>
    /// <param name="boardTitle">The title itself.</param>
    /// <returns>The inner value of the <see cref="BoardTitle"/> object.</returns>
    public static implicit operator string(BoardTitle boardTitle) => boardTitle.Value;

    /// <summary>
    /// Equality operator for the <see cref="BoardTitle"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is BoardTitle title)
        {
            return title.Value == Value;
        }

        return false;
    }
}
