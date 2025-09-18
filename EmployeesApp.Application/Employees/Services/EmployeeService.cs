using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {

        _employeeRepository = employeeRepository;
    }
    public async Task AddAsync(Employee employee)
    {

        var allEmployees = _employeeRepository.GetAllAsync();


         await _employeeRepository.AddAsync(employee);



        // File.WriteAllText(@"C:\Users\bror\Documents\kaka.txt", $"Adding employee {employee.Id}");

    }

    public async Task <Employee[]> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }


    public async Task <Employee?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id must be greater than 0");

        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            throw new ArgumentException($"Employee with Id {id} not found");

        return  employee;
    }



    public async Task UpdateAsync(Employee employee)
    {
        await _employeeRepository.UpdateAsync(employee);
    }








    public async Task ConnectToCompanyAsync(int employeeId, int companyId)
    {

        var employee = await _employeeRepository.GetByIdAsync(employeeId);
        if (employee != null)
        {

            employee.CompanyId = companyId;
             await _employeeRepository.UpdateAsync(employee);


        }


    }











}



