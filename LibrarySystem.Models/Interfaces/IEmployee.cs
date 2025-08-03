using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Enums;

namespace LibrarySystem.Models.Interfaces;

public interface IEmployee
{
    public OpStatusEnum Add(Employee employee);
    public Employee Login(string emailAddress, string password);
}
