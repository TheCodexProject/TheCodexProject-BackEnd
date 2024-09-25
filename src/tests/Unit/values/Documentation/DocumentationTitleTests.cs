using domain.exceptions.documentation.documentationTitle;
using domain.exceptions.project.ProjectTitle;
using domain.models.documentation.values;
using Xunit;

namespace Unit.values.documentation
{
    public class DocumentationTitleTests
    {
        /// <summary>
        /// Test to check if DocumentationTitle value object will not let you create an empty title.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Empty_Is_Failure()
        {
            // Arrange
            var title = string.Empty;

            // Act
            var result = DocumentationTitle.Create(title);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that the correct exception is thrown for an empty title.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Empty_Exception_Check()
        {
            // Arrange
            var title = string.Empty;

            // Act
            var result = DocumentationTitle.Create(title);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationTitleEmptyException);
        }

        /// <summary>
        /// Test to check if DocumentationTitle value object will not let you create a too short title.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Too_Short_Is_Failure()
        {
            // Arrange
            var title = "ab";

            // Act
            var result = DocumentationTitle.Create(title);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that the correct exception is thrown for a too short title.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Too_Short_Exception_Check()
        {
            // Arrange
            var title = "ab";

            // Act
            var result = DocumentationTitle.Create(title);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationTitleTooShortException);
        }

        /// <summary>
        /// Test to check if DocumentationTitle value object will not let you create a too long title.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Too_Long_Is_Failure()
        {
            // Arrange
            var title = new string('a', 76);

            // Act
            var result = DocumentationTitle.Create(title);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that the correct exception is thrown for a too long title.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Too_Long_Exception_Check()
        {
            // Arrange
            var title = new string('a', 76);

            // Act
            var result = DocumentationTitle.Create(title);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is DocumentationTitleTooLongException);
        }

        /// <summary>
        /// Test to check that you are allowed to create a title with a valid length (between 3 and 75 characters).
        /// </summary>
        [Fact]
        public void Title_Can_Be_Valid_Length()
        {
            // Arrange
            var title = "Valid Documentation Title";

            // Act
            var result = DocumentationTitle.Create(title);

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}
