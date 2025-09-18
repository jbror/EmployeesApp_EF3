namespace EmployeesApp.Web.Views.Employees;

public class EmployeeIndexVM
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    public string? CompanyName { get; set; }  // Bind and use this in View -- HERE


}
