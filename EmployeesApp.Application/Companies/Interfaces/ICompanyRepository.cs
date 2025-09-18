using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Companies.Interfaces;

public interface ICompanyRepository
{


    Task<Company[]> GetAllAsync();

    Task AddAsync(Company company);




}