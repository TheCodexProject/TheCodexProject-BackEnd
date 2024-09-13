using System.Reflection;
using domain.models.Users.values;

namespace domain.models.Users;

public class UserFactory
{
    /// <summary>
    /// The user that is being created.
    /// </summary>
    private readonly User _user = User.Create();
    
    /// <summary>
    /// Initializes the creation of a new <see cref="User"/>.
    /// </summary>
    /// <returns></returns>
    public static UserFactory Create()
    {
        return new UserFactory();
    }
    
    // ! NOTE: THE FOLLOWING METHODS CAN CREATE INVALID STATES FOR USER, SINCE IT USES REFLECTION TO SET VALUES DIRECTLY
    // ! WHICH MEANS THAT IT CAN BYPASS THE VALIDATION RULES OF THE USER CLASS
    // ! 🔴 ONLY USE THIS FOR TESTING PURPOSES 🔴
    
    /// <summary>
    /// Adds a first name to the user.
    /// </summary>
    /// <param name="firstName">First name to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public UserFactory WithFirstName(string firstName)
    {
        var firstNameConstructor = typeof(FirstName)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(string)}, null);
        if (firstNameConstructor == null) throw new NullReferenceException("FirstName constructor not found");
        
        var fName = (FirstName) firstNameConstructor.Invoke(new object[] {firstName});
        
        const string property = "FirstName";
        
        var firstNameProperty = typeof(User).GetProperty(property);
        if (firstNameProperty == null) throw new NullReferenceException($"{property} property not found");
        
        firstNameProperty.SetValue(_user, fName);
        return this;
    }
    
    /// <summary>
    /// Adds a last name to the user.
    /// </summary>
    /// <param name="lastName">Last name to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public UserFactory WithLastName(string lastName)
    {
        var lastNameConstructor = typeof(LastName)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(string)}, null);
        if (lastNameConstructor == null) throw new NullReferenceException("LastName constructor not found");
        
        var lName = (LastName) lastNameConstructor.Invoke(new object[] {lastName});
        
        const string property = "LastName";
        
        var lastNameProperty = typeof(User).GetProperty(property);
        if (lastNameProperty == null) throw new NullReferenceException($"{property} property not found");
        
        lastNameProperty.SetValue(_user, lName);
        return this;
    }
    
    /// <summary>
    /// Adds an email to the user.
    /// </summary>
    /// <param name="email">Email to be set.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public UserFactory WithEmail(string email)
    {
        var emailConstructor = typeof(Email)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(string)}, null);
        if (emailConstructor == null) throw new NullReferenceException("Email constructor not found");
        
        var mail = (Email) emailConstructor.Invoke(new object[] {email});
        
        const string property = "Email";
        
        var emailProperty = typeof(User).GetProperty(property);
        if (emailProperty == null) throw new NullReferenceException($"{property} property not found");
        
        emailProperty.SetValue(_user, mail);
        return this;
    }
    
    /// <summary>
    /// Returns the built user.
    /// </summary>
    /// <returns>A <see cref="User"/> with a set of values.</returns>
    public User Build()
    {
        return _user;
    }
}