using OperationResult;

namespace domain.interfaces;

/// <summary>
/// A builder interface for building objects.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBuilder<T>
{
    /// <summary>
    /// Builds the object.
    /// </summary>
    /// <returns>The built object.</returns>
    Result<T> Build();

    /// <summary>
    /// Generates a default object with default values.
    /// </summary>
    /// <returns></returns>
    Result<T> MakeDefault();

}