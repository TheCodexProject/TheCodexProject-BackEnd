using domain.exceptions.documentation.documentationFormat;
using domain.models.Documentation.values;
using Xunit;

namespace Unit.values.Documentation
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
        /// Test to check if DocumentationFormat value object will not let you create a too long format.
        /// </summary>
        [Fact]
        public void Format_Cannot_Be_Too_Long_Is_Failure()
        {
            // Arrange
            var format = new string('a', 6);

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
            var format = new string('a', 6);

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationFormatTooLongException);
        }

        /// <summary>
        /// Test to check that you are allowed to create a format with a valid length (between 1 and 5).
        /// </summary>
        [Fact]
        public void Format_Can_Be_Valid_Length()
        {
            // Arrange
            var format = "valid";

            // Act
            var result = DocumentationFormat.Create(format);

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}
