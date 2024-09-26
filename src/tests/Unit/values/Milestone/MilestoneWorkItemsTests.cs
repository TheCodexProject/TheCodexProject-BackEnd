using domain.models.milestone;
using domain.models.workItem;
using Xunit;
using System;

namespace Unit.models.milestone
{
    public class MilestoneTests
    {
        /// <summary>
        /// Test to ensure a work item can be successfully added to the Milestone.
        /// </summary>
        [Fact]
        public void AddWorkItem_Should_Add_WorkItem_To_Milestone()
        {
            // Arrange
            var milestone = Milestone.Create();
            var workItem = WorkItemBuilder.Create().MakeDefault();

            // Act
            milestone.AddWorkItem(workItem);

            // Assert
            Assert.Contains(workItem.Value.Id, milestone.WorkItems);
        }

        /// <summary>
        /// Test to ensure an exception is thrown when trying to add a null work item.
        /// </summary>
        [Fact]
        public void AddWorkItem_Should_Throw_Exception_When_WorkItem_Is_Null()
        {
            // Arrange
            var milestone = Milestone.Create();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => milestone.AddWorkItem(null));
        }

        /// <summary>
        /// Test to ensure a work item can be successfully removed from the Milestone.
        /// </summary>
        [Fact]
        public void RemoveWorkItem_Should_Remove_WorkItem_From_Milestone()
        {
            // Arrange
            var milestone = Milestone.Create();
            var workItem = WorkItemBuilder.Create().MakeDefault();
            milestone.AddWorkItem(workItem);

            // Act
            var result = milestone.RemoveWorkItem(workItem);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.DoesNotContain(workItem.Value.Id, milestone.WorkItems);
        }

        /// <summary>
        /// Test to ensure an exception is thrown when trying to remove a null work item.
        /// </summary>
        [Fact]
        public void RemoveWorkItem_Should_Throw_Exception_When_WorkItem_Is_Null()
        {
            // Arrange
            var milestone = Milestone.Create();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => milestone.RemoveWorkItem(null));
        }

        /// <summary>
        /// Test to ensure removing a work item that does not exist in the Milestone returns a failure result.
        /// </summary>
        [Fact]
        public void RemoveWorkItem_Should_Return_Failure_When_WorkItem_Does_Not_Exist()
        {
            // Arrange
            var milestone = Milestone.Create();
            var workItem = WorkItemBuilder.Create().MakeDefault();

            // Act
            var result = milestone.RemoveWorkItem(workItem);

            // Assert
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test to ensure a Milestone is created with an empty list of work items.
        /// </summary>
        [Fact]
        public void Create_Should_Initialize_With_Empty_WorkItems_List()
        {
            // Act
            var milestone = Milestone.Create();

            // Assert
            Assert.NotNull(milestone.WorkItems);
            Assert.Empty(milestone.WorkItems);
        }
    }
}
