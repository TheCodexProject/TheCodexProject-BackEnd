using domain.exceptions.board.boardTitle;
using domain.exceptions.board.boardQuery;
using domain.exceptions;
using domain.models.board;

namespace Unit.models.board;

public class BoardBuilderTests
{
    /// <summary>
    /// Test to ensure that the builder creates a default board with default values.
    /// </summary>
    [Fact]
    public void BoardBuilder_Makes_Default_Board_Successfully()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder.MakeDefault();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Test to ensure that the builder can chain methods together successfully.
    /// </summary>
    [Fact]
    public void BoardBuilder_Chains_Methods_Successfully()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder
            .WithTitle(BoardConstants.DefaultTitle)
            .WithQuery(BoardConstants.DefaultQuery())
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Test to ensure that the builder fails when no required fields are provided.
    /// </summary>
    [Fact]
    public void BoardBuilder_Builds_With_No_Required_Fields_Fails()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder.Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that the builder fails when an empty title is provided.
    /// </summary>
    [Fact]
    public void BoardBuilder_Builds_With_Empty_Title_Fails()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder.WithTitle("").Build();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
    }

    /// <summary>
    /// Test to ensure that the builder fails when a null title is provided.
    /// </summary>
    [Fact]
    public void BoardBuilder_Builds_With_Null_Title_Fails()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder.WithTitle(null).Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that the builder fails when no query is provided.
    /// </summary>
    [Fact]
    public void BoardBuilder_Builds_With_No_Query_Fails()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder.WithTitle("Test Board").Build();  // No query provided

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
    }

    /// <summary>
    /// Test to check if BoardTitleEmptyException is replaced by RequiredFieldMissingException in the build process.
    /// </summary>
    [Fact]
    public void BoardBuilder_Changes_BoardTitleEmptyException_To_RequiredFieldMissingException()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder.WithTitle("").Build(); // Empty title triggers BoardTitleEmptyException

        // Assert
        Assert.True(result.IsFailure);

        // Ensure that the error list contains RequiredFieldMissingException instead of BoardTitleEmptyException
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        Assert.DoesNotContain(result.Errors, e => e is BoardTitleEmptyException);

        // Check if the inner exception of RequiredFieldMissingException is BoardTitleEmptyException
        var requiredFieldMissingException = result.Errors.OfType<RequiredFieldMissingException>().FirstOrDefault();
        Assert.NotNull(requiredFieldMissingException);
        Assert.IsType<BoardTitleEmptyException>(requiredFieldMissingException.InnerException);
    }
}