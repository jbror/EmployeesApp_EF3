using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Application.Employees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public ICompanyRepository Companies { get; }
    public IEmployeeRepository Employees { get; }
    private readonly ApplicationContext _context;





    public UnitOfWork(
        ApplicationContext context,
        ICompanyRepository companyRepository,
        IEmployeeRepository employeeRepository)
    {
        _context = context;
        Companies = companyRepository;
        Employees = employeeRepository;

    }





    public async Task PersistAllAsync()
    {

        await _context.SaveChangesAsync();

    }














}
