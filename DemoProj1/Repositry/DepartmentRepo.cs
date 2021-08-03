using DemoProj1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Repositry
{
    public class DepartmentRepo : IDepartment,ILogger
    {
        private readonly studentDbContext DbContext;
     //   private readonly ILogger log;

        public DepartmentRepo(studentDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public IQueryable<Department> Add(Department department)
        {
            //throw new NotImplementedException();
            return DbContext.Department.FromSqlRaw("exec insertDept {0}, {1}, {2}", department.Id, department.DeptName, department.DeptStrength);
            //DbContext.SaveChanges();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            DbContext.Department.FromSqlRaw("exec deleteDeptByID 3");
            DbContext.SaveChanges();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> Read()
        {
            //throw new NotImplementedException();
            //return DbContext.Departments.ToList();
            return DbContext.Department.FromSqlRaw("exec getDeptDetails");


        }

        public IQueryable<Department> Readkey(int key)
        {
            //throw new NotImplementedException();
           
                return DbContext.Department.FromSqlRaw("exec depDetailsbyID {0}", key);
            
        }
    }
}
