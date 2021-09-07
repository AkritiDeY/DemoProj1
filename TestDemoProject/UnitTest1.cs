using AutoFixture;
using AutoFixture.AutoNSubstitute;
using DemoProj1.Controllers;
using DemoProj1.Models;
using DemoProj1.Repositry;
using DemoProj1.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestDemoProject
{ 
    public class UnitTest1
    {
        
       // private readonly Istudentservices stud;
        [Fact]
        public void StudentControllerTest_shouldReturnStudentList()
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            
            var context = fixture.Create<StudentContext>();

          // var request = fixture.Create<studentDetails1>();
            //fixture.Customize<studentDetails1>(c => c.Without(i => i.StudId));

            var requestStud = fixture.Build<studentDetails1>().Without(i => i.StudId).Create();

            //fixture.Build<Person>().Without(p => p.Spouse).CreateAnonymous();

            
            var sut = new StudentRepo(context);

            var response = sut.Add(requestStud);

            List<studentDetails1> studentDetails = new List<studentDetails1>()
            {
                new studentDetails1
                {
                    //StudId = 0,
                    FirstName = "Amar",
                    LastName = "ban",
                    Age = 22

                }
            };
            response.ToList().First().Should().BeEquivalentTo(studentDetails.First());



            /*studentDetails1 st = new studentDetails1();
            st.Age = 22;
            st.FirstName = "Anuj";
            st.LastName = "Kumar";
            st.StudId = 8;*/

            //StudentController sc = new StudentController();
            //var res = sc.Post(st);
        }
    }
}
