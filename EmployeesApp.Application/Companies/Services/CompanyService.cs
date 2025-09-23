using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Domain.Entities;


namespace EmployeesApp.Application.Companies.Services;


public class CompanyService : ICompanyService
{

    private readonly IUnitOfWork _unitOfWork;
   // private readonly ICompanyRepository _companyRepository;
    public CompanyService (IUnitOfWork unitOfWork)
    {

        _unitOfWork = unitOfWork;
       // _companyRepository = companyRepository;
    }

     



    public async Task <Company[]> GetAllAsync()
    {
        return await _unitOfWork.Companies.GetAllAsync();
    }


    public async Task AddAsync(Company company)
    {

       //var allCompany = _unitOfWork.Companies.GetAllAsync();


        await _unitOfWork.Companies.AddAsync(company);
        await _unitOfWork.PersistAllAsync();



        // File.WriteAllText(@"C:\Users\bror\Documents\kaka.txt", $"Adding employee {employee.Id}");

    }


    public async Task<Company?> GetAsync(int companyId)
    {
        return await _unitOfWork.Companies.GetAsync(companyId);
    }












}