using domain.exceptions;
using domain.exceptions.milestone.milestoneTitle;
using domain.models.milestone;
using Xunit;
using System.Linq;

namespace Unit.models.milestone
{
    public class MilestoneBuilderTests
    {
        // MakeDefault - Ensure the builder creates a default milestone with default values.
        [Fact]
        public void MilestoneBuilder_Makes_Default_Milestone_Successfully()
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
        public void MilestoneBuilder_Chains_Methods_Successfully()
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
        public void MilestoneBuilder_Builds_With_No_Required_Fields_Fails()
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
        public void MilestoneBuilder_Builds_With_Empty_Required_Fields_Fails()
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
        public void MilestoneBuilder_Builds_With_Null_Required_Fields_Fails()
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
        public void MilestoneBuilder_Changes_MilestoneTitleEmptyException_To_RequiredFieldMissingException()
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
    }
}
