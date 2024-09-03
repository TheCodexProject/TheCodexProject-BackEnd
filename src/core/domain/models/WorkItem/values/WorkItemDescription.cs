using domain.exceptions.WorkItem.WorkItemDescription;
using OperationResult;

namespace domain.models.workItem.values;

public class WorkItemDescription
{
    private string Value { get; }
    
    /// <summary>
    /// Used for EFC (Entity Framework Core)
    /// </summary>
    private WorkItemDescription() {}
    
    private WorkItemDescription(string value)
    {
        Value = value;
    }
    
    /// <summary>
    /// Factory method to create a new instance of the <see cref="WorkItemDescription"/> class.
    /// </summary>
    /// <param name="value">Description to use</param>
    /// <returns> A <see cref="Result"/> indicating if the creation was a success or not.</returns>
    public static Result<WorkItemDescription> Create(string value)
    {
        var result = Validate(value);
        
        if (result.IsFailure)
        {
            return Result<WorkItemDescription>.Failure(result.Errors.ToArray());
        }
        
        var workItemDescription = new WorkItemDescription(value);
        
        return workItemDescription;
    }

    /// <summary>
    /// Validates the work item description.
    /// </summary>
    /// <param name="value">Description to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the validation was a success or not.</returns>
    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (value.Length > 500)
        {
            errors.Add(new WorkItemDescriptionTooLongException());
        }
        
        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }
    
    /// <summary>
    /// Implicitly converts a <see cref="WorkItemDescription"/> to a <see cref="string"/>.
    /// </summary>
    /// <param name="description">The description itself.</param>
    /// <returns>The inner value of the <see cref="WorkItemDescription"/> object.</returns>
    public static implicit operator string(WorkItemDescription description) => description.Value;

    /// <summary>
    /// Equality operator for the <see cref="WorkItemDescription"/> class.
    /// </summary>
    /// <param name="obj">Object to check.</param>
    /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is WorkItemDescription description)
        {
            return description.Value == Value;
        }

        return false;
    }
}