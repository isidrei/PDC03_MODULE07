using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PDC03_MODULE07.Model; 

namespace PDC03_MODULE07.ViewModel
{
    public class EmployeeViewModel
    {
        //call database
        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        // Insert Records
        public int InsertEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        //Retrieve Records
        public async Task<List<EmployeeModel>> getAllEmployees()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Employee.ToListAsync();
            return res;
        }

        //Update
        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        //Delete
        public int DeleteEmployee(EmployeeModel obj) 
        {
            var _dbContext = getContext();
            _dbContext.Employee.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}

