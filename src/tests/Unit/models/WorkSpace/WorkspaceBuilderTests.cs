using domain.exceptions.Workspace.WorkspaceTitle;
using domain.exceptions;
using domain.exceptions.workspace;
using domain.models.workspace;
using domain.models.project;
using domain.models.user;
using Xunit;
using System.Collections.Generic;

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
        var user = WorkspaceConstants.DefaultOwner;

        // Act
        var result = builder
            .WithTitle(WorkspaceConstants.DefaultTitle)
            .WithOwner(user)
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
            .WithTitle("")
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
            .WithTitle(null)
            .WithOwner(null)
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
            .WithTitle("") // Empty title triggers WorkspaceTitleEmptyException
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
            .WithTitle("Title")
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

    // Add Projects - Ensure projects are added successfully.
    [Fact]
    public void WorkspaceBuilder_Adds_Projects_Successfully()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();
        var project1 = Project.Create(); // Replace with a valid way to create a Project instance
        var project2 = Project.Create();
        var projects = new List<Project> { project1, project2 };

        // Act
        var result = builder
            .WithTitle(WorkspaceConstants.DefaultTitle)
            .WithOwner(WorkspaceConstants.DefaultOwner)
            .WithProjects(projects)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(2, result.Value.Projects.Count);
    }

    // Add Contacts - Ensure contacts are added successfully.
    [Fact]
    public void WorkspaceBuilder_Adds_Contacts_Successfully()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();
        var user1 = User.Create(); // Replace with a valid way to create a User instance
        var user2 = User.Create();
        var contacts = new List<User> { user1, user2 };

        // Act
        var result = builder
            .WithTitle(WorkspaceConstants.DefaultTitle)
            .WithOwner(WorkspaceConstants.DefaultOwner)
            .WithContacts(contacts)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(2, result.Value.Contacts.Count);
    }

    // Add Empty Project List - Ensure that adding an empty project list succeeds.
    [Fact]
    public void WorkspaceBuilder_Adds_Empty_Project_List_Successfully()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();
        var projects = new List<Project>();

        // Act
        var result = builder
            .WithTitle(WorkspaceConstants.DefaultTitle)
            .WithOwner(WorkspaceConstants.DefaultOwner)
            .WithProjects(projects)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Value.Projects);
    }

    // Add Empty Contact List - Ensure that adding an empty contact list succeeds.
    [Fact]
    public void WorkspaceBuilder_Adds_Empty_Contact_List_Successfully()
    {
        // Arrange
        var builder = WorkspaceBuilder.Create();
        var contacts = new List<User>();

        // Act
        var result = builder
            .WithTitle(WorkspaceConstants.DefaultTitle)
            .WithOwner(WorkspaceConstants.DefaultOwner)
            .WithContacts(contacts)
            .Build();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Value.Contacts);
    }
}
