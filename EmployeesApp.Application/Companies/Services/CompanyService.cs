using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Domain.Entities;


namespace EmployeesApp.Application.Companies.Services;


public class CompanyService : ICompanyService
{

    private readonly ICompanyRepository _companyRepository;
    public CompanyService (ICompanyRepository companyRepository)
    {

        _companyRepository = companyRepository;
    }

     



    public async Task <Company[]> GetAllAsync()
    {
        return await _companyRepository.GetAllAsync();
    }


    public async Task AddAsync(Company company)
    {

        var allCompany = _companyRepository.GetAllAsync();


         await _companyRepository.AddAsync(company);



        // File.WriteAllText(@"C:\Users\bror\Documents\kaka.txt", $"Adding employee {employee.Id}");

    }


    public async Task<Company?> GetAsync(int companyId)
    {
        return await _companyRepository.GetAsync(companyId);
    }












}