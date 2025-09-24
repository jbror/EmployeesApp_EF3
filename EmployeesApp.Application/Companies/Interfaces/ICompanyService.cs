using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Companies.Interfaces;
public interface ICompanyService
{

    Task <Company[]> GetAllAsync();

    Task AddAsync(Company company);

    Task<Company?> GetAsync(int companyId);

    Task DeleteAsync(int companyId);


}