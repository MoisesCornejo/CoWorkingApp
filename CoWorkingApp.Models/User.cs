namespace CoWorkingApp.Models;

public class User // clase usuario
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? LasName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}