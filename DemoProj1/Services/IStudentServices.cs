using DemoProj1.Models;
using DemoProj1.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Services
{
  public  interface IStudentServices
    {
      

        public IEnumerable<studentDetails1> GetStudent();
        public IEnumerable<studentDetails1> AddStudentAsync(studentDetails1 student);

        public int EditStudent(studentDetails1 student);

        public IEnumerable<studentDetails1> GetStudentByKey(int key);

        public int DeleteStudent(int key);

    }
}
