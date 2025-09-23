using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Application.Employees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistence;

public class UnitOfWork
{

    public readonly ApplicationContext _context;
    public readonly ICompanyRepository _companyRepository;
    public readonly IEmployeeRepository _employeeRepository;


    public UnitOfWork(ApplicationContext context,
                      ICompanyRepository companyRepository,
                      IEmployeeRepository employeeRepository)
    {
        _context = context;
        _companyRepository = companyRepository;
        _employeeRepository = employeeRepository;



    }



    





}
