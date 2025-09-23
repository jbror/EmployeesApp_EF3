using EmployeesApp.Application.Employees.Interfaces;

namespace EmployeesApp.Application.Companies.Interfaces;

public interface IUnitOfWork
{
    

    ICompanyRepository Companies { get; }
    IEmployeeRepository Employees { get; }

    Task PersistAllAsync();
}