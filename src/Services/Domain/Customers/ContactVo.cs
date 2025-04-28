namespace Andromeda.Domain.Customers;

public record ContactVo
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private ContactVo() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public ContactVo(string phone, string email)
    {
        Phone = phone;
        Email = email;
    }

    public string Phone { get; private set; }
    public string Email { get; private set; }
}