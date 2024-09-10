using domain.models.Project.values;

namespace Unit.values.Project;

public class ProjectTimeRangeTests
{
    /// <summary>
    /// Test to check if ProjectTimeRange object will let you create a TimeRange object with a start time before end time 
    /// </summary>
    [Fact]
    public void TimeRange_End_Cannot_Be_Before_Start()
    {
        // Arrange
        var StartTime = DateTime.Today;
        var EndTime = DateTime.Today.AddDays(-1);

        // Act
        var result = ProjectTimeRange.Create(StartTime, EndTime);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Test to check if ProjectTimeRange object allows creation when start and end times are the same.
    /// </summary>
    [Fact]
    public void TimeRange_Can_Have_Same_Start_And_End()
    {
        // Arrange
        var StartTime = DateTime.Today;
        var EndTime = DateTime.Today;

        // Act
        var result = ProjectTimeRange.Create(StartTime, EndTime);

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Test to check if ProjectTimeRange object will allow valid time range where the end time is after the start time.
    /// </summary>
    [Fact]
    public void TimeRange_Valid_TimeRange_Returns_Success()
    {
        // Arrange
        var StartTime = DateTime.Today;
        var EndTime = DateTime.Today.AddDays(1);

        // Act
        var result = ProjectTimeRange.Create(StartTime, EndTime);

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Test to check if ProjectTimeRange correctly returns the start time when created.
    /// </summary>
    [Fact]
    public void TimeRange_Should_Return_Correct_StartTime()
    {
        // Arrange
        var StartTime = DateTime.Today;
        var EndTime = DateTime.Today.AddDays(1);

        // Act
        var result = ProjectTimeRange.Create(StartTime, EndTime);

        // Assert
        Assert.Equal(StartTime, result.Value.Start);
    }

    /// <summary>
    /// Test to check if ProjectTimeRange correctly returns the end time when created.
    /// </summary>
    [Fact]
    public void TimeRange_Should_Return_Correct_EndTime()
    {
        // Arrange
        var StartTime = DateTime.Today;
        var EndTime = DateTime.Today.AddDays(1);

        // Act
        var result = ProjectTimeRange.Create(StartTime, EndTime);

        // Assert
        Assert.Equal(EndTime, result.Value.End);
    }
}
