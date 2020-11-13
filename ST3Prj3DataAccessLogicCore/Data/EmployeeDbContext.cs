using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ST3Prj3DomaineCore.Models;

namespace ST3Prj3DataAccessLogicCore.Data
{
    public class EmployeeDbContext : DbContext
    {
        #region Contructor
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            //When migrations is not enabled i the database use make sure the datase is created
            Database.EnsureCreated();

            //Following is Exlusive to "Data base.EnsureCreated();" and is used when Migration is enable and a at least one migration is added to the propject
            //Database.Migration();
        }
        #endregion

        #region Public properties
        public DbSet<Employee> Employee { get; set; }
        #endregion

        #region Overridden method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(GetEmployees());
            base.OnModelCreating(modelBuilder);
        }
        #endregion


        #region Private method
        private List<Employee> GetEmployees()
        {
            return new List<Employee>
        {
            new Employee {Id = 100, FirstName ="John", LastName = "Doe"},
            new Employee {Id = 101, FirstName ="Nicole", LastName = "Martha"},
            new Employee {Id = 102, FirstName ="Steve", LastName = "Johnson"},
            new Employee {Id = 103, FirstName ="Thomas", LastName = "Bond"},
        };
        }
        #endregion
    }
}
