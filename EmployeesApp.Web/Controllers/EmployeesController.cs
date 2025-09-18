using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Web.Views.Home;
using Microsoft.Extensions.Logging;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;
using EmployeesApp.Web.Views.Employees;
using EmployeesApp.Application.Companies.Interfaces;

namespace EmployeesApp.Web.Controllers;

[Route("employee")]
public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController>? logger = null) // Nu med filter och ILogger
    {
        _employeeService = employeeService;
        _logger = logger ?? NullLogger<EmployeesController>.Instance;
    }


    [HttpGet("")]
    public async Task <IActionResult> EmployeeIndexAsync()
    {

        var employees = (await _employeeService.GetAllAsync());
        var viewModels = employees.Select(e => new EmployeeIndexVM
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            Salary = e.Salary,
            CompanyName = e.Company?.Name ?? "" 

        }).ToList();
        _logger.LogInformation("Number of employees: {count}", viewModels.Count);

        return View(viewModels);



    }



    [HttpGet("create")] 
    public IActionResult EmployeeCreate()
    {

        return View(new EmployeeCreateVM());
    }








    [HttpPost("create")]
    public async Task <IActionResult> CreateAsync(EmployeeCreateVM vm)
    {

        if (ModelState.IsValid)
        {
            var employee = new Employee
            {

                Name = vm.Name,
                Email = vm.Email,
                Salary = vm.Salary
            };

           await _employeeService.AddAsync(employee);
            _logger.LogInformation("New employee created! Name: {Name}", employee.Name);
            return RedirectToAction("EmployeeIndex");
        }

        return View(vm);
    }







}
