namespace EmployeesApp.Web.Views.Employees;

public class HomeEmployeeIndexVM
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    public string? CompanyName { get; set; }
}
