namespace Andromeda.Domain.Customers;

public class Customer : Entity, IAggregateRoot
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Customer() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public Customer(string name, ContactVo contact)
    {
        Name = name;
        Contact = contact;
    }

    public string Name { get; private set; }
    public ContactVo Contact { get; private set; }
    

    public void Update(string name, ContactVo contact)
    {
        Name = name;
        Contact = contact;
    }
}