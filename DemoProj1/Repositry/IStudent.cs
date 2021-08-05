using DemoProj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Repositry
{
    public interface IStudent
    {
        IEnumerable<studentDetails1> Add(studentDetails1 student);
        IEnumerable<studentDetails1> Read();
        IEnumerable<studentDetails1> Readkey(int key);
        int Delete(int key);
        int Edit(studentDetails1 student);
    }
}
