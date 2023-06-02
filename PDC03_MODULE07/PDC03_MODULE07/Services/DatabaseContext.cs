using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using PDC03_MODULE07.Model;


namespace PDC03_MODULE07.Services
{
    public class DatabaseContext: DbContext
    {
        public DbSet<EmployeeModel> Employee { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Employee.db");
            optionBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
