using domain.models.user;

namespace domain.models.workspace;

public static class WorkspaceConstants
{
    /// <summary>
    /// A default title to be used for testing purposes.
    /// </summary>
    public const string DefaultTitle = "No title";

    public static readonly User DefaultOwner = User.Create();
}
