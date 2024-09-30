using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace domain.exceptions.milestone.milestoneTitle;

[Serializable]
public class MilestoneTitleTooLongException : Exception
{
    public MilestoneTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }

    public MilestoneTitleTooLongException(string message) : base(message) { }

    public MilestoneTitleTooLongException(string message, Exception innerException) : base(message, innerException) { }

    protected MilestoneTitleTooLongException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}