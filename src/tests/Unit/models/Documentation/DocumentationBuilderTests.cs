﻿using domain.exceptions;
using domain.exceptions.documentation.documentationContent;
using domain.exceptions.documentation.documentationFormat;
using domain.exceptions.documentation.documentationTitle;
using domain.exceptions.project.ProjectTitle;
using domain.models.documentation;
using OperationResult;
using Xunit;

namespace Unit.values.documentation
{
    public class DocumentationBuilderTests
    {
        /// <summary>
        /// Test to see that a Documentation is created with default values.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Default_Values_Should_Have_Default_Values()
        {
            // Arrange & Act
            var documentation = DocumentationBuilder.Create()
                .MakeDefault();

            // Assert
            Assert.True(documentation.IsSuccess);
            Assert.Equal(DocumentationConstants.DefaultTitle, documentation.Value.Title);
            Assert.Equal(DocumentationConstants.DefaultFormat, documentation.Value.Format);
            Assert.Equal(DocumentationConstants.DefaultContent, documentation.Value.Content);
        }

        /// <summary>
        /// Test to see that creating Documentation with an empty title fails.
        /// </summary>
        [Fact]
        public void DocumentationBuilder_With_Empty_Title_Should_Fail()
        {
            // Arrange
            var builder = DocumentationBuilder.Create();

            // Act
            var result = builder
                .WithTitle("")
                .Build();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        }

        /// <summary>
        /// Test to see that creating Documentation with a null title fails.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Null_Title_Should_Fail()
        {
            // Act
            var documentation = DocumentationBuilder.Create()
                .WithTitle(null)
                .Build();

            // Assert
            Assert.True(documentation.IsFailure);
            Assert.Contains(documentation.Errors, e => e is RequiredFieldMissingException);
        }

        /// <summary>
        /// Test to see that creating Documentation with a title that is too short fails.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Short_Title_Should_Fail()
        {
            // Arrange
            var shortTitle = "a"; // Assuming the title should be longer than 1 character

            // Act
            var documentation = DocumentationBuilder.Create()
                .WithTitle(shortTitle)
                .Build();

            // Assert
            Assert.True(documentation.IsFailure);
            Assert.Contains(documentation.Errors, e => e is DocumentationTitleTooShortException);
        }

        /// <summary>
        /// Test to see that creating Documentation with an empty format fails.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Empty_Format_Should_Fail()
        {
            // Arrange
            var builder = DocumentationBuilder.Create();

            // Act
            var result = builder
                .WithTitle(DocumentationConstants.DefaultTitle)
                .WithFormat("")
                .WithContent(DocumentationConstants.DefaultContent)
                .Build();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        }

        /// <summary>
        /// Test to see that creating Documentation with a format that does not contain a dot fails.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Format_Without_Dot_Should_Fail()
        {
            // Arrange
            var formatWithoutDot = "docx"; // Format should contain a dot

            // Act
            var documentation = DocumentationBuilder.Create()
                .WithTitle(DocumentationConstants.DefaultTitle)
                .WithFormat(formatWithoutDot)
                .WithContent(DocumentationConstants.DefaultContent)
                .Build();

            // Assert
            Assert.True(documentation.IsFailure);
            Assert.Contains(documentation.Errors, e => e is DocumentationFormatDoesNotFollowConventionException);
            Assert.Contains(documentation.Errors, e => e is DocumentationFormatDoesNotStartWithDot);
        }

        /// <summary>
        /// Test to see that creating Documentation with a too long format fails.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Too_Long_Format_Should_Fail()
        {
            // Arrange
            var longFormat = "ABCDEFGHIJKLM"; // Assuming format length should not exceed 5 characters

            // Act
            var documentation = DocumentationBuilder.Create()
                .WithTitle(DocumentationConstants.DefaultTitle)
                .WithFormat(longFormat)
                .WithContent(DocumentationConstants.DefaultContent)
                .Build();

            // Assert
            Assert.True(documentation.IsFailure);
            Assert.Contains(documentation.Errors, e => e is DocumentationFormatTooLongException);
            Assert.Contains(documentation.Errors, e => e is DocumentationFormatDoesNotFollowConventionException);
            Assert.Contains(documentation.Errors, e => e is DocumentationFormatDoesNotStartWithDot);
        }

        /// <summary>
        /// Test to see that creating Documentation with valid title and format succeeds.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Valid_Title_And_Valid_Content_And_Invalid_Format_Should_Fail()
        {
            // Arrange
            var invalidFormat = "docx.";

            // Act
            var documentation = DocumentationBuilder.Create()
                .WithTitle(DocumentationConstants.DefaultTitle)
                .WithFormat(invalidFormat)
                .WithContent(DocumentationConstants.DefaultContent)
                .Build();

            // Assert
            Assert.True(documentation.IsFailure);
            Assert.Contains(documentation.Errors, e => e is DocumentationFormatDoesNotStartWithDot);
        }

        /// <summary>
        /// Test to see that creating Documentation with valid title and format succeeds.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Valid_Title_And_Format_And_Content_Should_Succeed()
        {
            // Arrange
            var validTitle = "Valid Title";
            var validFormat = ".docx";
            var validContent = "Valid Content";

            // Act
            var documentation = DocumentationBuilder.Create()
                .WithTitle(validTitle)
                .WithFormat(validFormat)
                .WithContent(validContent)
                .Build();

            // Assert
            Assert.True(documentation.IsSuccess);
            Assert.Equal(validTitle, documentation.Value.Title);
            Assert.Equal(validFormat, documentation.Value.Format);
        }

        /// <summary>
        /// Test to see that creating Documentation with empty content fails.
        /// </summary>
        [Fact]
        public void DocumentationBuilder_With_Empty_Content_Should_Fail()
        {
            // Arrange
            var builder = DocumentationBuilder.Create();

            // Act
            var result = builder
                .WithContent("")
                .Build();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is RequiredFieldMissingException);
        }

        /// <summary>
        /// Test to see that creating Documentation with a null content fails.
        /// </summary>
        [Fact]
        public void Create_Documentation_With_Null_Content_Should_Fail()
        {
            // Act
            var documentation = DocumentationBuilder.Create()
                .WithContent(null)
                .Build();

            // Assert
            Assert.True(documentation.IsFailure);
            Assert.Contains(documentation.Errors, e => e is RequiredFieldMissingException);
        }
    }
}
