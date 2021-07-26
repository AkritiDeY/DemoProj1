using DemoProj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Repositry
{
    public interface IDepartment
    {
        IQueryable<Department> Add(Department department);
        IQueryable<Department> Read();
        IQueryable<Department> Readkey(int key);

        void Delete(int key);

        //IEnumerable<studentDetails1> Edit(studentDetails1 student); 
    }
}
