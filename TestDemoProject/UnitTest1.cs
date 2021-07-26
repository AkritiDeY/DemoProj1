using DemoProj1.Controllers;
using DemoProj1.Models;
using DemoProj1.Repositry;
using System;
using Xunit;

namespace TestDemoProject
{
    public class UnitTest1
    {
        private readonly IStudent stud;
        [Fact]
        public void Test1()
        {
            studentDetails1 st = new studentDetails1();
            st.Age = 22;
            st.FirstName = "Anuj";
            st.LastName = "Kumar";
            st.StudId = 8;

            //StudentController sc = new StudentController();
            //var res = sc.Post(st);
        }
    }
}
