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

        public IEnumerable<studentDetails1> Add(studentDetails1 student)
        {
            DbContext.studentDetails1.Add(student);
            DbContext.SaveChanges();
            return DbContext.studentDetails1.ToList();

        }

        public int Delete(int key)
        {
            int temp = 0;
            studentDetails1 studItem = DbContext.studentDetails1.Where(p => p.StudId == key).FirstOrDefault();
            if (studItem != null)
            {
                temp = 1;
                DbContext.studentDetails1.Remove(studItem);
                DbContext.SaveChanges();
            }
            return temp;
        }

        public int Edit(studentDetails1 student)
        {
            int temp = 0;
            try
            {
                // var c= DbContext.studentDetails1.Where(p => p.StudId == student.StudId).FirstOrDefault();
                studentDetails1 studItem = DbContext.studentDetails1.Where(p => p.StudId == student.StudId).FirstOrDefault();
                // DbContext.studentDetails1.Update(student);
                //  DbContext.SaveChanges();
                if (studItem != null)
                {
                    temp = 1;
                    studItem.StudId = student.StudId;
                    studItem.FirstName = student.FirstName;
                    studItem.LastName = student.LastName;
                    studItem.Age = student.Age;
                    DbContext.SaveChanges();

                }

                
                DbContext.SaveChanges();
                

            }
            catch (Exception)
            {
                // return DbContext.studentDetails1.ToList();
            }
            return temp;
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
