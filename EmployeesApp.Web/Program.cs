
using EmployeesApp.Application.Companies.Interfaces;
using EmployeesApp.Application.Companies.Services;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Infrastructure.Persistence;
using EmployeesApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
                      
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>(); 


            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();




            //builder.Services.AddSingleton<IEmployeeService, OtherEmployeeService>();  // K�r med "test" data




            // H�mta connection-str�ngen fr�n AppSettings.json

            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            
            // Registrera Context-klassen f�r dependency injection
            builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connString));





            var app = builder.Build();
            app.UseStaticFiles  ();

            app.MapControllers();


            app.Run();
        }
    }
}

