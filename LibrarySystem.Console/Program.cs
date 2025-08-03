using LibrarySystem.Models.Entities;
using LibrarySystem.Services;
using System;

namespace LibrarySystem.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Library System Console Application");

            var employeeService = new EmployeeService();
            var employee1 = new Employee();

            employee1.Id = 1;
            employee1.Name = "Osama";
            employee1.EmailAddress = "osama@osama.com";
            employee1.Password = "123456";
            employee1.CreatedAt = DateTime.UtcNow;
            employee1.CreatedBy = 1; ;

            employeeService.Add(employee1);

            var result1 = employeeService.Login("osama@osama.com", "123456");
            var result2 = employeeService.Login("osama@osama.com", "1234567");



        }
    }
}
