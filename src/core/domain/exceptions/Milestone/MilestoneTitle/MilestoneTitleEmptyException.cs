using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace domain.exceptions.milestone.milestoneTitle;

/// <summary>
/// Exception for when a Milestone is created without a title.
/// </summary>
[Serializable]
public class MilestoneTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public MilestoneTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public MilestoneTitleEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public MilestoneTitleEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MilestoneTitleEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}