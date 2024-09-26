
using domain.exceptions.iteration.iterationTitle;
using domain.exceptions;
using domain.models.iteration;

namespace Unit.models.iteration;

public class IterationBuilderTests
{
    // MakeDefault - Ensure the builder creates a default iteration with default values.
    [Fact]
    public void IterationBuilder_Makes_Default_Iteration_Successfully()
    {
        // Arrange
        var builder = IterationBuilder.Create();

        // Act
        var result = builder.MakeDefault();

        // Assert
        Assert.True(result.IsSuccess);
    }

    // Chaining - Ensure the builder can chain methods together.
    [Fact]
    public void IterationBuilder_Chains_Methods_Successfully()
    {
        // Arrange
        var builder = IterationBuilder.Create();

        // Act
        var result = builder
            .withTitle(IterationConstants.DefaultTitle)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
    }

    // No Required Fields - Ensure the builder cannot build the iteration with no required fields (Title).
    [Fact]
    public void IterationBuilder_Builds_With_No_Required_Fields_Fails()
    {
        // Arrange
        var builder = IterationBuilder.Create();

        // Act
        var result = builder.Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    // Empty Required Fields - Ensure the builder cannot build the iteration with empty required fields (Title).
    [Fact]
    public void IterationBuilder_Builds_With_Empty_Required_Fields_Fails()
    {
        // Arrange
        var builder = IterationBuilder.Create();

        // Act
        var result = builder.withTitle("").Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    // Null Required Fields - Ensure the builder cannot build the iteration with null required fields (Title).
    [Fact]
    public void IterationBuilder_Builds_With_Null_Required_Fields_Fails()
    {
        // Arrange
        var builder = IterationBuilder.Create();

        // Act
        var result = builder.withTitle(null).Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    // Test to check if IterationTitleEmptyException is replaced by RequiredFieldMissingException in the build process.
    [Fact]
    public void IterationBuilder_Changes_IterationTitleEmptyException_To_RequiredFieldMissingException()
    {
        // Arrange
        var builder = IterationBuilder.Create();

        // Act
        var result = builder
            .withTitle("") // Empty title triggers IterationTitleEmptyException
            .Build();

        // Assert
        Assert.True(result.IsFailure);
        // Ensure that the error list contains RequiredFieldMissingException instead of IterationTitleEmptyException
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        Assert.DoesNotContain(result.Errors, e => e is IterationTitleEmptyException);

        // Check if the inner exception of RequiredFieldMissingException is IterationTitleEmptyException
        var requiredFieldMissingException = result.Errors.OfType<RequiredFieldMissingException>().FirstOrDefault();
        Assert.NotNull(requiredFieldMissingException);
        Assert.IsType<IterationTitleEmptyException>(requiredFieldMissingException.InnerException);
    }

}
