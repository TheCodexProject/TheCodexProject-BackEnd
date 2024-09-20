using domain.models.Project.values;
using domain.models.workItem.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.models.Project;

public class ProjectConstants
{
    /// <summary>
    /// The default title for a <see cref="Project"/>. (No title)
    /// </summary>
    public static readonly String DefaultTitle = "No Title";

    /// <summary>
    /// The default description for a <see cref="Project"/>. (No description)
    /// </summary>
    public static readonly String DefaultDescription = "No Description";

    /// <summary>
    /// The default priority for a <see cref="Project"/>. (Low)
    /// </summary>
    public static readonly ProjectPriority DefaultPriority = ProjectPriority.Low;

    /// <summary>
    /// The default status for a <see cref="Project"/>. (Not Started)
    /// </summary>
    public static readonly ProjectStatus DefaultStatus = ProjectStatus.NotStarted;

    /// <summary>
    /// The default methodology for a <see cref="Project"/>. (Task)
    /// </summary>
    public static readonly ProjectMethodology DefaultMethodology = ProjectMethodology.None;

    /// <summary>
    /// The default start time for a <see cref="Project"/>. (Task)
    /// </summary>
    public static readonly DateTime DefaultStartTime = DateTime.MinValue;

    /// <summary>
    /// The default end time for a <see cref="Project"/>. (Task)
    /// </summary>
    public static readonly DateTime DefaultEndTime = DateTime.MinValue.AddDays(1);
}