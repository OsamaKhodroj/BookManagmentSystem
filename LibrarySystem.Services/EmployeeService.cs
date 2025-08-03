using LibrarySystem.Infrastctures;
using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Enums;
using LibrarySystem.Models.Interfaces;

namespace LibrarySystem.Services;

public class EmployeeService : IEmployee
{
    private List<Employee>? _employees;

    public EmployeeService()
    {
        if (_employees == null)
        {
            _employees = new List<Employee>();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public OpStatusEnum Add(Employee employee)
    {
        try
        {
            if (employee == null)
                throw new Exception("Employee not found");

            IsValidData(employee);

            employee.Password = Encryption.Hash(employee.Password);
            
            _employees?.Add(employee);
            return OpStatusEnum.Success;
        }
        catch (Exception ex)
        {
            return OpStatusEnum.InternalServerError;
        }
    }
     
    /// <summary>
    /// 
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public Employee Login(string emailAddress, string password)
    {
        try
        {
            var employee = _employees?.Where(q => q.EmailAddress == emailAddress)
                .FirstOrDefault();

            if (employee == null)
                throw new Exception("Employee not found");

            var isValid = Encryption.Verify(password, employee.Password);
          
            if (!isValid)
                throw new Exception("Invalid password");

            return employee;
        }
        catch (Exception ex)
        { 
            throw ex;
        }

    }

    private bool IsValidData(Employee employee)
    {
        if (string.IsNullOrEmpty(employee.Name))
            throw new ArgumentNullException("Name is required");

        if (string.IsNullOrEmpty(employee.EmailAddress))
            throw new ArgumentNullException("EmailAddress is required");

        if (string.IsNullOrEmpty(employee.Password))
            throw new ArgumentNullException("Password is required");

        var isUserExists = _employees?.Any(q => q.EmailAddress == employee.EmailAddress);
        if (isUserExists == true)
            throw new Exception("Email address already exists");

        return true;
    }
}
