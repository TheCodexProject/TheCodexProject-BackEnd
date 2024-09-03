using OperationResult;

namespace unittesting.Tools.OperationResult;

public class ResultTests
{
   public const string ErrorMessage = "An error has occurred.";
   
   /// <summary>
   /// Test to assert that a successful result is not a failure.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Success")]
   public void Success_Result_IsFailure_Should_Be_False()
   {
      // Arrange
      var result = Result.Success();
      
      // Act
      var isFailure = result.IsFailure;
      
      // Assert
      Assert.False(isFailure);
   }
   
   /// <summary>
   /// Test to assert that a failed result is a failure.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_IsFailure_Should_Be_True()
   {
      // Arrange
      var result = Result.Failure(new Exception(ErrorMessage));
      
      // Act
      var isFailure = result.IsFailure;
      
      // Assert
      Assert.True(isFailure);
   }
   
   /// <summary>
   /// Test to assert that a failed result contains an error message.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_Errors_Should_Contain_Error_Message()
   {
      // Arrange
      var result = Result.Failure(new Exception(ErrorMessage));
      
      // Act
      var errors = result.Errors;
      
      // Assert
      Assert.Contains(ErrorMessage, errors.Select(e => e.Message));
   }
   
   /// <summary>
   /// Test to assert that a failed result can contain different error messages.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_Errors_Should_Contain_All_Error_Messages()
   {
      // Arrange
      var errorMessages = new[] { "Error 1", "Error 2", "Error 3" };
      var result = Result.Failure(errorMessages.Select(e => new Exception(e)).ToArray());
      
      // Act
      var errors = result.Errors;
      
      // Assert
      var exceptions = errors.ToList();
      Assert.Equal(errorMessages.Length, exceptions.Count());
      Assert.All(errorMessages, em => Assert.Contains(em, exceptions.Select(e => e.Message)));
   }

   /// <summary>
   /// Test to assert that a failed result can contain different exception types.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_Errors_Can_Be_Different_Exception_Types()
   {
      // Arrange
      var errors = new Exception[] { new ArgumentException(), new InvalidOperationException(), new ArgumentNullException() };
      var result = Result.Failure(errors);
      
      // Act
      var resultErrors = result.Errors;
      
      // Assert
      var exceptions = resultErrors.ToList();
      Assert.Equal(errors.Length, exceptions.Count());
      Assert.All(errors, e => Assert.Contains(e, exceptions));
   }
}

public class ResultOfTTests
{
   public const string ErrorMessage = "An error has occurred.";
   public const int Value = 10;
   
   [Fact]
   public void Success_Result_Create_Result_With_Value()
   {
      // Arrange
      var value = Value;
      
      // Act
      var result = Result<int>.Success(value);
      
      // Assert
      Assert.Equal(value, result.Value);
   }
   
   [Fact]
   public void Success_Result_Create_Result_With_Value_IsFailure_Should_Be_False()
   {
      // Arrange
      var value = Value;
      
      // Act
      var result = Result<int>.Success(value);
      
      // Assert
      Assert.False(result.IsFailure);
   }
   
   [Fact]
   public void Failure_Result_Create_Result_With_Error_Message_IsFailure_Should_Be_True()
   {
      // Arrange
      var result = Result<int>.Failure(new Exception(ErrorMessage));
      
      // Act
      var isFailure = result.IsFailure;
      
      // Assert
      Assert.True(isFailure);
   }
   
   [Fact]
   public void Failure_Result_Create_Result_With_Error_Message_Errors_Should_Contain_Error_Message()
   {
      // Arrange
      var result = Result<int>.Failure(new Exception(ErrorMessage));
      
      // Act
      var errors = result.Errors;
      
      // Assert
      Assert.Contains(ErrorMessage, errors.Select(e => e.Message));
   }
   
   [Fact]
   public void Failure_Result_Create_Result_With_Error_Message_Errors_Should_Contain_All_Error_Messages()
   {
      // Arrange
      var errorMessages = new[] { "Error 1", "Error 2", "Error 3" };
      var result = Result<int>.Failure(errorMessages.Select(e => new Exception(e)).ToArray());
      
      // Act
      var errors = result.Errors;
      
      // Assert
      var exceptions = errors.ToList();
      Assert.Equal(errorMessages.Length, exceptions.Count());
      Assert.All(errorMessages, em => Assert.Contains(em, exceptions.Select(e => e.Message)));
   }
   
   [Fact]
   public void Failure_Result_Create_Result_With_Error_Message_Errors_Can_Be_Different_Exception_Types()
   {
      // Arrange
      var errors = new Exception[] { new ArgumentException(), new InvalidOperationException(), new ArgumentNullException() };
      var result = Result<int>.Failure(errors);
      
      // Act
      var resultErrors = result.Errors;
      
      // Assert
      var exceptions = resultErrors.ToList();
      Assert.Equal(errors.Length, exceptions.Count());
      Assert.All(errors, e => Assert.Contains(e, exceptions));
   }
   
   [Fact]
   public void Implicit_Conversion_From_T_To_Result_T()
   {
      // Arrange
      var value = Value;
      
      // Act
      Result<int> result = value;
      
      // Assert
      Assert.Equal(value, result.Value);
   }
   
   [Fact]
   public void Implicit_Conversion_From_Result_T_To_T()
   {
      // Arrange
      var value = Value;
      var result = Result<int>.Success(value);
      
      // Act
      int resultValue = result;
      
      // Assert
      Assert.Equal(value, resultValue);
   }
   
   [Fact]
   public void Implicit_Conversion_From_Result_T_To_T_With_Failed_Result()
   {
      // Arrange
      var result = Result<int>.Failure(new Exception(ErrorMessage));
      
      // Act
      int resultValue = result;
      
      // Assert
      Assert.Equal(default(int), resultValue);
   }
}