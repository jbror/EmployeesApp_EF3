using EmployeesApp.Web.Views.Companies;
using EmployeesApp.Web.Views.Employees;

namespace EmployeesApp.Web.Views.Home;

//public class IndexVM
//{

//    public int Id { get; set; }
//    public string Name { get; set; } = string.Empty;
//    public string Email { get; set; } = string.Empty;
//    public decimal Salary { get; set; }


//}


public class HomeIndexVM
{
    public List<HomeEmployeeIndexVM> Employees { get; set; } = new();
    public List<HomeCompanyIndexVM> Companies { get; set; } = new();



}