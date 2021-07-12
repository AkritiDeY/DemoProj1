using DemoProj1.Models;
using DemoProj1.Repositry;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent stud;

        public StudentController(IStudent stud)
        {
            this.stud = stud;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<studentDetails1> Get()
        {
            return stud.Read().ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IEnumerable<studentDetails1> Get(int id)
        {
            IEnumerable<studentDetails1> get = stud.Readkey(id);
            return get.ToList();
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] studentDetails1 student )
        {
            stud.Add(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void PUT(int id, studentDetails1 student)
        {
            /*var customer1 = stud.Readkey(id);
            foreach(studentDetails1 s in customer1){
                customer1.Age = s.Age;
            }
            db.Entry(customer1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();*/
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            /*var del = stud.Readkey(id);
            stud.Delete(del);
            stud.SaveChanges();*/
        }
    }
}
