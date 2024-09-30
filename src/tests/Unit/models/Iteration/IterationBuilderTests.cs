
using domain.exceptions.iteration.iterationTitle;
using domain.exceptions;
using domain.models.iteration;
using domain.models.workItem;

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

    /// <summary>
    /// Test to ensure that work items are added successfully.
    /// </summary>
    [Fact]
    public void IterationBuilder_Adds_WorkItems_Successfully()
    {
        // Arrange
        var builder = IterationBuilder.Create();
        var workItemBuilder = WorkItemBuilder.Create(); // Create an instance of WorkItemBuilder

        var workItems = new List<WorkItem>
    {
        workItemBuilder.MakeDefault().Value,
        workItemBuilder.MakeDefault().Value,
    };

        // Act
        var result = builder
            .withTitle(IterationConstants.DefaultTitle)
            .WithWorkitems(workItems)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(workItems.Count, result.Value.WorkItems.Count);
    }

    /// <summary>
    /// Test to ensure that builder fails when invalid work items are provided.
    /// </summary>
    [Fact]
    public void IterationBuilder_With_Invalid_WorkItems_Fails()
    {
        // Arrange
        var builder = IterationBuilder.Create();
        var invalidWorkItems = new List<WorkItem>
        {
            null // Adding a null work item to simulate invalid input
        };

        // Act
        var result = builder
            .withTitle(IterationConstants.DefaultTitle)
            .WithWorkitems(invalidWorkItems)
            .Build();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, e => e is ArgumentNullException);
    }

    /// <summary>
    /// Test to ensure that builder adds work items and title successfully.
    /// </summary>
    [Fact]
    public void IterationBuilder_Adds_Title_And_WorkItems_Successfully()
    {
        // Arrange
        var builder = IterationBuilder.Create();
        var workItemBuilder = WorkItemBuilder.Create(); // Create an instance of WorkItemBuilder

        var workItems = new List<WorkItem>
    {
        workItemBuilder.MakeDefault().Value,
        workItemBuilder.MakeDefault().Value,
        workItemBuilder.MakeDefault().Value
    };

        // Act
        var result = builder
            .withTitle(IterationConstants.DefaultTitle)
            .WithWorkitems(workItems)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(workItems.Count, result.Value.WorkItems.Count);
        Assert.Equal(IterationConstants.DefaultTitle, result.Value.Title);
    }


}
