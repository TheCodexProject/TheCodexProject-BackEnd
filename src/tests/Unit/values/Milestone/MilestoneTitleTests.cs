﻿using domain.exceptions.milestone.milestoneTitle;
using domain.models.milestone.values;
using Xunit;
using System.Linq;

namespace Unit.values.Milestone
{
    public class MilestoneTitleTests
    {
        /// <summary>
        /// Test to check if MilestoneTitle value object will let you create an empty title.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Empty_Is_Failure()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that it hands the user the correct exception when title is empty.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Empty_Exception_Check()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is MilestoneTitleEmptyException);
        }

        /// <summary>
        /// Test to check that you cannot create a title with less than 3 characters.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Less_Than_Three_Characters_Is_Failure()
        {
            // Arrange
            var value = "A".PadRight(2, 'A');

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that it hands the user the correct exception when title is too short.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_Less_Than_Three_Characters_Exception_Check()
        {
            // Arrange
            var value = "A".PadRight(2, 'A');

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is MilestoneTitleTooShortException);
        }

        /// <summary>
        /// Test to check that you are allowed to create a title with 3 characters.
        /// </summary>
        [Fact]
        public void Title_Can_Be_Created_With_3_Characters()
        {
            // Arrange
            var value = "A".PadRight(3, 'A');

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(value, result.Value.Value);
        }

        /// <summary>
        /// Test to check that you cannot create a title with more than 75 characters.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_More_Than_75_Characters_Is_Failure()
        {
            // Arrange
            var value = "A".PadRight(76, 'A');

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure that it hands the user the correct exception when title is too long.
        /// </summary>
        [Fact]
        public void Title_Cannot_Be_More_Than_75_Characters_Exception_Check()
        {
            // Arrange
            var value = "A".PadRight(76, 'A');

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is MilestoneTitleTooLongException);
        }

        /// <summary>
        /// Test to check that you are allowed to create a title with 75 characters.
        /// </summary>
        [Fact]
        public void Title_Can_Be_Created_With_75_Characters()
        {
            // Arrange
            var value = "A".PadRight(75, 'A');

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(value, result.Value.Value);
        }

        /// <summary>
        /// Test to check that you are allowed to create a title with 25 characters (Which is within the limits.)
        /// </summary>
        [Fact]
        public void Title_Can_Be_Created_With_25_Characters()
        {
            // Arrange
            var value = "A".PadRight(25, 'A');

            // Act
            var result = MilestoneTitle.Create(value);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(value, result.Value.Value);
        }
    }
}
