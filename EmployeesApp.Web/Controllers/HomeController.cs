using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Web.Views.Home;
using Microsoft.Extensions.Logging;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;
using EmployeesApp.Web.Views.Employees;
using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Web.Views.Companies;

namespace EmployeesApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<HomeController> _logger;
    private readonly ICompanyService _companyService;

    public HomeController(IEmployeeService employeeService, ICompanyService companyService, ILogger<HomeController> logger) 
    {
        _employeeService = employeeService;
        _companyService = companyService;
        _logger = logger;
    }

    [HttpGet("")]
    public async Task <IActionResult> IndexAsync()
    {
        var employees = (await _employeeService.GetAllAsync())
        .Select(e => new HomeEmployeeIndexVM
        {
            Id = e.Id,  
            Name = e.Name,
            Email = e.Email,
            Salary = e.Salary,
            CompanyName = e.Company != null ? e.Company.Name : ""

        }).ToList();

        var companies = (await _companyService.GetAllAsync())
            .Select(c => new HomeCompanyIndexVM()
            {
                Id = c.Id,
                Name = c.Name,
                EmployeesCount = c.Employees.Count()
            }).ToList();

        var viewModel = new HomeIndexVM()
        {
            Employees = employees,
            Companies = companies
        };


        _logger.LogInformation($"Number of employees: {viewModel.Employees.Count} Number of companies {viewModel.Companies.Count}" );



        return View(viewModel);
    }







}
