using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using EmployeesApp.Application.Employees.Interfaces;

using Microsoft.EntityFrameworkCore; // for my demo


namespace EmployeesApp.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationContext _context;

    public EmployeeRepository(ApplicationContext context)
    {
        _context = context;
    }
    




    public async Task AddAsync(Employee employee)
    {

       await _context.Employees.AddAsync(employee);
       await _context.SaveChangesAsync();
        

        //File.WriteAllText(@"C:\Users\bror\Documents\kaka.txt", $"Adding employee {employee.Id}");

    }

    public async Task<Employee[]> GetAllAsync()
    {
        return await _context.Employees
        .Include(e => e.Company)
        .ToArrayAsync();


    }



    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
        .FindAsync(id);

    }



    public async Task UpdateAsync(Employee employee)
    {
         _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }




    public void Remove(Employee employee)
    {
        _context.Remove(employee);
    }




}