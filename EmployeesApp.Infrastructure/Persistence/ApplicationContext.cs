using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistence;

// Denna konstruktor krävs för att konfigurationen ska fungera
public class ApplicationContext(DbContextOptions<ApplicationContext> options)
: DbContext(options)
{
    // Exponerar våra databas-modeller via properties av typen DbSet<T>
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Employee>()
            .Property(e => e.Salary)
            .HasColumnType("money");




        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, Name = "TobaksLivs Kiruna" },
            new Company { Id = 2, Name = "TobaksLivs Gbg" },
            new Company { Id = 3, Name = "TobaksLivs Stockholm"}
            );




        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Klas Boman", Email = "superklas@gmail.com", Salary = 30000.00m },
            new Employee { Id = 2, Name = "Saga Citron", Email = "saga56@gmail.com", Salary = 100000m },
            new Employee { Id = 3, Name = "Nate Gowig", Email = "natego@outlook.com", Salary = 25000m }


            );




    }
}
