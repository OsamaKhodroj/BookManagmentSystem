namespace LibrarySystem.Models.Entities;

public class Employee : BaseEntity
{
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
