using domain.exceptions.Workspace.WorkspaceTitle;
using domain.exceptions;
using domain.exceptions.Workspace;
using domain.models.workspace;
using Xunit;

namespace Unit.models.WorkspaceTests;

public class WorkspaceBuilderTests
{
    // MakeDefault - Ensure the builder creates a default workspace with default values.
    [Fact]
    public void WorkspaceBuilder_Makes_Default_Workspace_Successfully()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();

        // Act
        var result = builder
            .MakeDefault();

        // Assert
        Assert.True(result.IsSuccess);
    }

    // Chaining - Ensure the builder can chain methods together.
    [Fact]
    public void WorkspaceBuilder_Chains_Methods_Successfully()
    {
        // Arrange
    
        var builder = WorkspaceBuilder.Create();
        var user = domain.models.user.User.Create();
        
        // Act
        var result = builder
            .withTitle(WorkspaceConstants.DefaultTitle)
            .withOwner(user)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
    }

    // No Required Fields - Ensure the builder cannot build the workspace with no required fields (Title).
    [Fact]
    public void WorkspaceBuilder_Builds_With_No_Required_Fields_Fails()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();

        // Act
        var result = builder
            .Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    // Empty Required Fields - Ensure the builder cannot build the workspace with empty required fields (Title).
    [Fact]
    public void WorkspaceBuilder_Builds_With_Empty_Required_Fields_Fails()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();

        // Act
        var result = builder
            .withTitle("")
            .Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    // Null Required Fields - Ensure the builder cannot build the workspace with null required fields (Title).
    [Fact]
    public void WorkspaceBuilder_Builds_With_Null_Required_Fields_Fails()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();

        // Act
        var result = builder
            .withTitle(null)
            .withOwner(null)
            .Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    // Test to check if WorkspaceTitleEmptyException is replaced by RequiredFieldMissingException in the build process.
    [Fact]
    public void WorkspaceBuilder_Changes_WorkspaceTitleEmptyException_To_RequiredFieldMissingException()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();

        // Act
        var result = builder
            .withTitle("") // Empty title triggers WorkspaceTitleEmptyException
            .Build();

        // Assert
        Assert.True(result.IsFailure);
        // Ensure that the error list contains RequiredFieldMissingException instead of WorkspaceTitleEmptyException
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        Assert.DoesNotContain(result.Errors, e => e is WorkspaceTitleEmptyException);

        // Check if the inner exception of RequiredFieldMissingException is WorkspaceTitleEmptyException
        var requiredFieldMissingException = result.Errors.OfType<RequiredFieldMissingException>().FirstOrDefault();
        Assert.NotNull(requiredFieldMissingException);
        Assert.IsType<WorkspaceTitleEmptyException>(requiredFieldMissingException.InnerException);
    }
    
    // Test to verify that not setting the owner returns a failure with RequiredFieldMissingException with an inner exception of WorkspaceOwnerEmptyException.
    [Fact]
    public void WorkspaceBuilder_Changes_WorkspaceOwnerEmptyException_To_RequiredFieldMissingException()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();

        // Act
        var result = builder
            .withTitle("Title")
            .Build();

        // Assert
        Assert.True(result.IsFailure);
        // Ensure that the error list contains RequiredFieldMissingException instead of WorkspaceOwnerEmptyException
        Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        Assert.DoesNotContain(result.Errors, e => e is WorkspaceOwnerEmptyException);

        // Check if the inner exception of RequiredFieldMissingException is WorkspaceOwnerEmptyException
        var requiredFieldMissingException = result.Errors.OfType<RequiredFieldMissingException>().FirstOrDefault();
        Assert.NotNull(requiredFieldMissingException);
        Assert.IsType<WorkspaceOwnerEmptyException>(requiredFieldMissingException.InnerException);
    }
}

