using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Web.Views.Employees;

public class EmployeeCreateVM
{

    [Required(ErrorMessage = "You must have a name! Enter name!")]
    public string Name { get; set; } = string.Empty;



    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter valid email please!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Salary is required")]
    public decimal Salary { get; set; }


}

