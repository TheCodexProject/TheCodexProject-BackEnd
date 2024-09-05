using domain.models.User.values;

namespace domain.models.User;

public class User
{
    public Guid Id { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public Email Email { get; set; }
    // TODO: Add a username & password property here, when working on authentication.
}