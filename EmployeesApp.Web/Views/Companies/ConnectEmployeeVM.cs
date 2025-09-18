using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesApp.Web.Views.Companies;

public class ConnectEmployeeVM
{


    public int? SelectedEmployeeId { get; set; }
    public int? SelectedCompanyId { get; set; }

    public List<SelectListItem> Employees { get; set; } = new();
    public List<SelectListItem> Companies { get; set; } = new();




}
