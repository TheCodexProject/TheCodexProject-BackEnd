using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace domain.exceptions.Project.ProjectStatus;

/// <summary>
/// Exception for when a Project is created without a status.
/// </summary>
[Serializable]
public class ProjectStatusEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectStatusEmptyException() : base("Status cannot be left empty.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectStatusEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public ProjectStatusEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected ProjectStatusEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}