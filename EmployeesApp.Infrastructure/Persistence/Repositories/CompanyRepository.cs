using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationContext _context;

    public CompanyRepository(ApplicationContext context)
    {
        _context = context;
    }


    public async Task<Company[]> GetAllAsync()
    {
        return await _context.Companies
            .Include(c => c.Employees)
            .ToArrayAsync();



    }




    public async Task AddAsync(Company company)
    {

        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();


        //File.WriteAllText(@"C:\Users\bror\Documents\kaka.txt", $"Adding employee {employee.Id}");

    }


    public async Task<Company?> GetAsync(int companyId)
    {

        return await  _context.Companies
            .FindAsync(companyId);



    }

    public void Remove(Company company) // here!!!!!!!!!!!!!!!!!!!!!!
    {
        _context.Companies.Remove(company);
        
    }




}