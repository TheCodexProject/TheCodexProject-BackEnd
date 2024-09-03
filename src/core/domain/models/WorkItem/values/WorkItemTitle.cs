using domain.exceptions.WorkItem.WorkItemTitle;
using OperationResult;

namespace domain.models.workItem.values;

public class WorkItemTitle
{
   private string Value { get; }
   
   /// <summary>
   /// Used for EFC (Entity Framework Core)
   /// </summary>
   private WorkItemTitle() {}
    
   /// <summary>
   /// The private constructor for the <see cref="WorkItemTitle"/> class.
   /// </summary>
   /// <param name="value"></param>
   private WorkItemTitle(string value)
   {
       Value = value;
   }

   /// <summary>
   /// Factory method to create a new instance of the <see cref="WorkItemTitle"/> class.
   /// </summary>
   /// <param name="value">Title to use.</param>
   /// <returns>A <see cref="Result"/> indicating if the creation was a success or not.</returns>
   public static Result<WorkItemTitle> Create(string value)
   { 
      var result = Validate(value);
      
      if (result.IsFailure) 
      { 
           return Result<WorkItemTitle>.Failure(result.Errors.ToArray());
      }
      
      var workItemTitle = new WorkItemTitle(value);
       
      return workItemTitle;
   }

   /// <summary>
   /// Validates the work item title.
   /// </summary>
   /// <param name="value">Title to be validated.</param>
   /// <returns> A named tuple contains a <see cref="bool"/> indicating if the validation has failed or not, and a list of errors that has ocurred.</returns>
   private static Result Validate(string value)
   {
       var errors = new List<Exception>();
       
       if (string.IsNullOrEmpty(value)) 
       {
            errors.Add(new WorkItemTitleEmptyException());
            return Result.Failure(errors.ToArray());
       }

       switch (value)
       {
           case { Length: < 3}:
               errors.Add(new WorkItemTitleTooShortException());
               break;
           case { Length: > 75}:
               errors.Add(new WorkItemTitleTooLongException());
               break;
       }

       return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
   }
   
   /// <summary>
   /// Implicit conversion from <see cref="WorkItemTitle"/> to <see cref="string"/>
   /// </summary>
   /// <param name="workItemTitle">The title itself.</param>
   /// <returns>The inner value of the <see cref="WorkItemTitle"/> object.</returns>
   public static implicit operator string(WorkItemTitle workItemTitle) => workItemTitle.Value;

   /// <summary>
   /// Equality operator for the <see cref="WorkItemTitle"/> class.
   /// </summary>
   /// <param name="obj">Object to check.</param>
   /// <returns>A <see cref="bool"/> indicating if it is equal.</returns>
   public override bool Equals(object? obj)
   {
       if(obj is WorkItemTitle title)
       {
           return title.Value == Value;
       }
       
       return false;
   }
}