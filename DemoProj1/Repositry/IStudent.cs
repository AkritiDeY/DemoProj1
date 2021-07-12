using DemoProj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Repositry
{
    public interface IStudent
    {
        studentDetails1 Add(studentDetails1 student);
        IEnumerable<studentDetails1> Read();
        IEnumerable<studentDetails1> Readkey(int key);
        void Delete(int key);
        studentDetails1 Edit(int key);
    }
}
