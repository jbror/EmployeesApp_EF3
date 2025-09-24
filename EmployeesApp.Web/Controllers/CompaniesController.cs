using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Views.Companies;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesApp.Web.Controllers;


[Route("company")]
public class CompaniesController : Controller
{

    private readonly ICompanyService _companyService;
    private readonly IEmployeeService _employeeService;

    public CompaniesController(ICompanyService companyService, IEmployeeService employeeService )
    {
        _companyService = companyService;
        _employeeService = employeeService;
    }





    [HttpGet("")]
    public  async Task <IActionResult> CompanyIndexAsync()
    {
        var company = (await _companyService.GetAllAsync());
        var viewModel = company.Select(c => new CompanyIndexVM
        {
            Id = c.Id,
            Name = c.Name,
            EmployeesCount = c.Employees.Count 
        }).ToList();
        return View(viewModel);


        }




    [HttpGet("create")]
    public IActionResult CompanyCreate()
    {
        return View(new CompanyCreateVM());
    }





    [HttpPost("create")]
    public async Task <IActionResult> CreateAsync(CompanyCreateVM vm)
    {

        if (ModelState.IsValid)
        {
            var company = new Company
            {

                Name = vm.Name
               
            };

             await _companyService.AddAsync(company);
            //_logger.LogInformation("New company created! Name: {Name}", company.Name);
            return RedirectToAction("CompanyIndex");
        }

        return View(vm);
    }



    
    [HttpGet("connect")]
    public async Task <IActionResult> ConnectEmployeeAsync()
    {
        var model = new ConnectEmployeeVM
        {
            Employees = (await _employeeService.GetAllAsync())
                .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name })
                .ToList(),

            Companies = (await _companyService.GetAllAsync())
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList()
        };

        return View(model);
    }




    [HttpPost("connect")]
    public async Task <IActionResult> ConnectEmployeeAsync(ConnectEmployeeVM model)
    {

        if (model.SelectedEmployeeId.HasValue && model.SelectedCompanyId.HasValue)
        {
            await _employeeService.ConnectToCompanyAsync(model.SelectedEmployeeId.Value, model.SelectedCompanyId.Value);
            return RedirectToAction("CompanyIndex");
        }

        ModelState.AddModelError("", "Choose one employee and one company.");
        return View(model);



        }






    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetCompanyAsync(int id)
    {
        var company = await _companyService.GetAsync(id);

        if (company == null)
            return NotFound();

        return Ok(company);





    }

    // Run this in browserDebugger : fetch('/delete/id', { method: 'POST' });


    [HttpPost("/delete/{id}")]
    public async Task<IActionResult> RemoveCompany(int id)
    {

        //var company = await _companyService.GetAsync(id);

        //    if (company == null)
        //    return NotFound();

        await _companyService.DeleteAsync(id);
        return RedirectToAction("CompanyIndex");





    }
















}





































//        // GET: CompaniesController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: CompaniesController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: CompaniesController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: CompaniesController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: CompaniesController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: CompaniesController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: CompaniesController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
