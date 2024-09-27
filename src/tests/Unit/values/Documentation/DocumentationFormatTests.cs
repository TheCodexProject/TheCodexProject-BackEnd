using domain.exceptions.documentation.documentationFormat;
using domain.exceptions.project.ProjectTitle;
using domain.models.documentation.values;
using Xunit;

namespace Unit.values.documentation
{
    public class DocumentationFormatTests
    {
        /// <summary>
        /// Test to check if DocumentationFormat value object will not let you create an empty format.
        /// </summary>
        [Fact]
        public void Format_Cannot_Be_Empty_Is_Failure()
        {
            // Arrange
            var format = string.Empty;

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that the correct exception is thrown for an empty format.
        /// </summary>
        [Fact]
        public void Format_Cannot_Be_Empty_Exception_Check()
        {
            // Arrange
            var format = string.Empty;

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationFormatEmptyException);
        }

        /// <summary>
        /// Test to check if DocumentationFormat value object will not let you create a too short format.
        /// </summary>
        [Fact]
        public void Format_Cannot_Be_Too_Short_Is_Failure()
        {
            // Arrange
            var format = "a";

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that the correct exception is thrown for a too short format.
        /// </summary>
        [Fact]
        public void Format_Cannot_Be_Too_Short_Exception_Check()
        {
            // Arrange
            var format = "a";

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationFormatTooShortException);
            Assert.Contains(result.Errors, e => e is DocumentationFormatDoesNotStartWithDot);
            Assert.Contains(result.Errors, e => e is DocumentationFormatDoesNotFollowConventionException);
        }

        /// <summary>
        /// Test to check if DocumentationFormat value object will not let you create a too long format.
        /// </summary>
        [Fact]
        public void Format_Cannot_Be_Too_Long_Is_Failure()
        {
            // Arrange
            var format = new string('a', 10);

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that the correct exception is thrown for a too long format.
        /// </summary>
        [Fact]
        public void Format_Cannot_Be_Too_Long_Exception_Check()
        {
            // Arrange
            var format = new string('a', 11);

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationFormatTooLongException);
            Assert.Contains(result.Errors, e => e is DocumentationFormatDoesNotStartWithDot);
            Assert.Contains(result.Errors, e => e is DocumentationFormatDoesNotFollowConventionException);
        }

        /// <summary>
        /// Test to check if DocumentationFormat value object will not let you create a format that does not contain a dot ('.').
        /// </summary>
        [Fact]
        public void Format_Does_Not_Contain_Dot_Is_Failure()
        {
            // Arrange
            var format = "docx";

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that the correct exception is thrown for a format that does not contain a dot ('.').
        /// </summary>
        [Fact]
        public void Format_Does_Not_Contain_Dot_Exception_Check()
        {
            // Arrange
            var format = "docx";

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationFormatDoesNotStartWithDot);
            Assert.Contains(result.Errors, e => e is DocumentationFormatDoesNotFollowConventionException);
        }

        /// <summary>
        /// Test to check that you are allowed to create a format with a valid format string.
        /// </summary>
        [Fact]
        public void Format_Contains_Dot_In_Wrong_Place_Check()
        {
            // Arrange
            var format = "docx.";

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to check that you are allowed to create a format with a valid format string.
        /// </summary>
        [Fact]
        public void Format_Is_Correct()
        {
            // Arrange
            var format = ".docx";

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}
