using DemoProj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Repositry
{
    public class StudentRepo : IStudent
    {
        private readonly StudentContext DbContext;

        public StudentRepo(StudentContext dbContext)
        {
            DbContext = dbContext;
        }

        public studentDetails1 Add(studentDetails1 student)
        {
            DbContext.studentDetails1.Add(student);
            DbContext.SaveChanges();
            return student;
            
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public studentDetails1 Edit(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<studentDetails1> Read()
        {
            return DbContext.studentDetails1.ToList();
        }

        public IEnumerable<studentDetails1> Readkey(int key)
        {
            // throw new NotImplementedException();

            return DbContext.studentDetails1.Where(p => p.StudId == key).ToList();

            //return DbContext.studentDetails1.ToList();
        }
    }
}
