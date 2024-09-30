using domain.exceptions.milestone;
using domain.models.milestone;
using domain.models.workItem;

namespace Unit.models.milestone
{
    public class MilestoneTests
    {
        /// <summary>
        /// Ensures that a list of work items can be added to the milestone successfully.
        /// </summary>
        [Fact]
        public void AddWorkItems_Should_Add_WorkItems_To_Milestone()
        {
            // Arrange
            var milestone = Milestone.Create();
            var workItems = MilestoneConstants.DefaultWorkItems;

            // Act
            var result = milestone.AddWorkItems(workItems);

            // Assert
            Assert.True(result.IsSuccess);
            foreach (var workItem in workItems)
            {
                Assert.Contains(workItem.Id, milestone.WorkItems);
            }
        }

        /// <summary>
        /// Ensures that adding a null list of work items throws an exception.
        /// </summary>
        [Fact]
        public void AddWorkItems_Should_Return_Failure_When_WorkItems_List_Is_Null()
        {
            // Arrange
            var milestone = Milestone.Create();
            List<WorkItem> workItems = null;

            // Act
            var result = milestone.AddWorkItems(workItems);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is MilestoneWorkItemNotFoundException);
        }

        /// <summary>
        /// Ensures that a work item can be removed from the milestone.
        /// </summary>
        [Fact]
        public void RemoveWorkItem_Should_Remove_WorkItem_From_Milestone()
        {
            // Arrange
            var milestone = Milestone.Create();
            var workItem = WorkItemBuilder.Create().MakeDefault();
            var workItems = new List<WorkItem> { workItem };
            milestone.AddWorkItems(workItems);

            // Act
            var result = milestone.RemoveWorkItem(workItem);

            // Assert
            Assert.True(result.IsSuccess);
            foreach (var item in workItems)
            {
                Assert.DoesNotContain(item.Id, milestone.WorkItems);
            }
        }

        /// <summary>
        /// Ensures that removing a null work item throws an exception.
        /// </summary>
        [Fact]
        public void RemoveWorkItem_Should_Return_Failure_When_WorkItem_Is_Null()
        {
            // Arrange
            var milestone = Milestone.Create();

            // Act
            var result = milestone.RemoveWorkItem(null);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(result.Errors, e => e is MilestoneWorkItemNotFoundException);
        }

        /// <summary>
        /// Ensures that removing a work item that does not exist returns a failure.
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
        /// Ensures that a milestone is initialized with an empty list of work items.
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
