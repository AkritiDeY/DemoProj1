using DemoProj1.Models;
using DemoProj1.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Services
{
    public class Service : IStudentServices
    {
        private readonly IStudent _stud;

        public Service(IStudent stud)
        {
            _stud = stud;
        }

        public IEnumerable<studentDetails1> AddStudent(studentDetails1 student)
        {
            return _stud.Add(student);
        }

        public int DeleteStudent(int key)
        {
           return _stud.Delete(key);
        }

        public int EditStudent(studentDetails1 student)
        {
            return _stud.Edit(student);
        }

        public IEnumerable<studentDetails1> GetStudent()
        {
             return _stud.Read();
        }

        public IEnumerable<studentDetails1> GetStudentByKey(int key)
        {
            return _stud.Readkey(key);
        }
    }

}
