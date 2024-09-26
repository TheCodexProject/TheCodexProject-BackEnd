using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace domain.exceptions.milestone.milestoneTitle;

[Serializable]
public class MilestoneTitleTooShortException : Exception
{
    public MilestoneTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }

    public MilestoneTitleTooShortException(string message) : base(message) { }

    public MilestoneTitleTooShortException(string message, Exception innerException) : base(message, innerException) { }

    protected MilestoneTitleTooShortException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}