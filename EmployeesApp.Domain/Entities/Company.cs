using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Domain.Entities;

public class Company
{

    public int Id { get; set; }

    
    public string Name { get; set; } = string.Empty;


    public ICollection<Employee> Employees { get; set; } = new List<Employee>();



    // public int EmployeesCount { get; set; }


    // public List<Employee> Employees { get; set; } = new ();



}
