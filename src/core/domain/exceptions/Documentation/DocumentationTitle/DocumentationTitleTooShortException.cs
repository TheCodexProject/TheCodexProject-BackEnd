﻿using System.Runtime.Serialization;

namespace domain.exceptions.project.ProjectTitle;

/// <summary>
/// Exception for when a documentation title is too short.
/// </summary>
[Serializable]
public class DocumentationTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public DocumentationTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public DocumentationTitleTooShortException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DocumentationTitleTooShortException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DocumentationTitleTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}