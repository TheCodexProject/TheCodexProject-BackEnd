using domain.exceptions.milestone.milestoneTitle;
using domain.exceptions.milestone;
using domain.exceptions;
using domain.models.milestone;
using domain.models.workItem;

namespace Unit.models.milestone
{
    public class MilestoneBuilderTests
    {
        // MakeDefault - Ensure the builder creates a default milestone with default values.
        [Fact]
        public void MilestoneBuilder_MakeDefault_Should_Create_Default_Milestone_Successfully()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();

            // Act
            var result = builder.MakeDefault();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(MilestoneConstants.DefaultTitle, result.Value.Title.Value);
        }

        // Chaining - Ensure the builder can chain methods together.
        [Fact]
        public void MilestoneBuilder_Chaining_Methods_Should_Chain_Successfully()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();

            // Act
            var result = builder
                .WithTitle(MilestoneConstants.DefaultTitle)
                .Build();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(MilestoneConstants.DefaultTitle, result.Value.Title.Value);
        }

        // No Required Fields - Ensure the builder cannot build the milestone with no required fields (Title).
        [Fact]
        public void MilestoneBuilder_Build_With_No_Required_Fields_Should_Fail()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();

            // Act
            var result = builder.Build();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        }

        // Empty Required Fields - Ensure the builder cannot build the milestone with empty required fields (Title).
        [Fact]
        public void MilestoneBuilder_Build_With_Empty_Required_Fields_Should_Fail()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();

            // Act
            var result = builder.WithTitle("")
                .Build();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        }

        // Null Required Fields - Ensure the builder cannot build the milestone with null required fields (Title).
        [Fact]
        public void MilestoneBuilder_Build_With_Null_Required_Fields_Should_Fail()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();

            // Act
            var result = builder.WithTitle(null).Build();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        }

        // Test to check if MilestoneTitleEmptyException is replaced by RequiredFieldMissingException in the build process.
        [Fact]
        public void MilestoneBuilder_Should_Change_MilestoneTitleEmptyException_To_RequiredFieldMissingException()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();

            // Act
            var result = builder
                .WithTitle("") // Empty title triggers MilestoneTitleEmptyException
                .Build();

            // Assert
            Assert.True(result.IsFailure);
            // Ensure that the error list contains RequiredFieldMissingException instead of MilestoneTitleEmptyException
            Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
            Assert.DoesNotContain(result.Errors, e => e is MilestoneTitleEmptyException);

            // Check if the inner exception of RequiredFieldMissingException is MilestoneTitleEmptyException
            var requiredFieldMissingException = result.Errors.OfType<RequiredFieldMissingException>().FirstOrDefault();
            Assert.NotNull(requiredFieldMissingException);
            Assert.IsType<MilestoneTitleEmptyException>(requiredFieldMissingException.InnerException);
        }

        // Ensure the builder adds a list of work items to the milestone.
        [Fact]
        public void MilestoneBuilder_With_WorkItems_Should_Add_WorkItems_Successfully()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();
            var workItems = MilestoneConstants.DefaultWorkItems;

            // Act
            var result = builder.WithTitle(MilestoneConstants.DefaultTitle).WithWorkItems(workItems).Build();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Value.WorkItems.Count);
            foreach (var workItem in workItems)
            {
                Assert.Contains(workItem.Id, result.Value.WorkItems);
            }
        }

        // Ensure that adding an empty list of work items doesn't break the builder.
        [Fact]
        public void MilestoneBuilder_With_WorkItems_Empty_List_Should_Not_Throw_Error()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();
            var workItems = new List<WorkItem>();

            // Act
            var result = builder.WithTitle(MilestoneConstants.DefaultTitle).WithWorkItems(workItems).Build();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Value.WorkItems);
        }

        // Ensure that passing a null list of work items to the builder returns failure.
        [Fact]
        public void MilestoneBuilder_With_WorkItems_Null_List_Should_Return_Failure()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();

            // Act
            var result = builder.WithWorkItems(null).Build();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is MilestoneWorkItemNotFoundException);
        }

        // Ensure the builder can chain multiple methods, including WithWorkItems.
        [Fact]
        public void MilestoneBuilder_Chaining_With_WorkItems_Should_Chain_Methods_Successfully()
        {
            // Arrange
            var builder = MilestoneBuilder.Create();
            var workItems = MilestoneConstants.DefaultWorkItems;

            // Act
            var result = builder
                .WithTitle(MilestoneConstants.DefaultTitle)
                .WithWorkItems(workItems)
                .Build();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(MilestoneConstants.DefaultTitle, result.Value.Title.Value);
            Assert.Equal(2, result.Value.WorkItems.Count);
            foreach (var workItem in workItems)
            {
                Assert.Contains(workItem.Id, result.Value.WorkItems);
            }
        }
    }
}
