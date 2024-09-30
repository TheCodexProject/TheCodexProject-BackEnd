using domain.exceptions.board.boardTitle;
using domain.exceptions;
using domain.models.board;
using System.Linq.Expressions;
using domain.models.workItem;

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
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
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

    /// <summary>
    /// Test to ensure that filters are added successfully.
    /// </summary>
    [Fact]
    public void BoardBuilder_Adds_Filters_Successfully()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder
            .WithTitle(BoardConstants.DefaultTitle)
            .WithFilters(BoardConstants.ExampleFilters)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(BoardConstants.ExampleFilters.Count, result.Value.Filters.Count);
    }

    /// <summary>
    /// Test to ensure that order-by expressions are added successfully.
    /// </summary>
    [Fact]
    public void BoardBuilder_Adds_OrderByExpressions_Successfully()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder
            .WithTitle(BoardConstants.DefaultTitle)
            .WithOrderBy(BoardConstants.ExampleOrderBys)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(BoardConstants.ExampleOrderBys.Count, result.Value.OrderByExpressions.Count);
    }

    /// <summary>
    /// Test to ensure that builder fails when invalid filters are provided.
    /// </summary>
    [Fact]
    public void BoardBuilder_With_Invalid_Filter_Fails()
    {
        // Arrange
        var builder = BoardBuilder.Create();
        var invalidFilters = new List<Expression<Func<WorkItem, bool>>>
        {
            null // Adding a null filter to simulate invalid input.
        };

        // Act
        var result = builder
            .WithTitle(BoardConstants.DefaultTitle)
            .WithFilters(invalidFilters)
            .Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that builder fails when invalid order-by expressions are provided.
    /// </summary>
    [Fact]
    public void BoardBuilder_With_Invalid_OrderBy_Fails()
    {
        // Arrange
        var builder = BoardBuilder.Create();
        var invalidOrderBys = new List<Expression<Func<WorkItem, object>>>
        {
            null // Adding a null order-by expression to simulate invalid input.
        };

        // Act
        var result = builder
            .WithTitle(BoardConstants.DefaultTitle)
            .WithOrderBy(invalidOrderBys)
            .Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to ensure that builder adds both filters and order-by expressions successfully.
    /// </summary>
    [Fact]
    public void BoardBuilder_Adds_Filters_And_OrderBy_Successfully()
    {
        // Arrange
        var builder = BoardBuilder.Create();

        // Act
        var result = builder
            .WithTitle(BoardConstants.DefaultTitle)
            .WithFilters(BoardConstants.ExampleFilters)
            .WithOrderBy(BoardConstants.ExampleOrderBys)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(BoardConstants.ExampleFilters.Count, result.Value.Filters.Count);
        Assert.Equal(BoardConstants.ExampleOrderBys.Count, result.Value.OrderByExpressions.Count);
    }
}
