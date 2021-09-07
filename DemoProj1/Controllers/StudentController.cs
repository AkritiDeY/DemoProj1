using DemoProj1.Models;
using DemoProj1.Repositry;
using DemoProj1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studserv;

        public StudentController(IStudentServices Studserv)
        {
          _studserv = Studserv;
            
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<studentDetails1> Get()
        {
            return _studserv.GetStudent().ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IEnumerable<studentDetails1> Get(int id)
        {
            IEnumerable<studentDetails1> get = _studserv.GetStudentByKey(id);
            return get.ToList();
        }

        // POST api/<StudentController>
        [HttpPost]
        public IEnumerable<studentDetails1> Post([FromBody] studentDetails1 student)
        {
            IEnumerable<studentDetails1> get = _studserv.AddStudentAsync(student);
            return get.ToList();
            //stud.Add(student);
            //return Ok(stud.Add(student));
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public int PUT([FromBody] studentDetails1 student)
        {
            /*var customer1 = stud.Readkey(id);
            foreach(studentDetails1 s in customer1){
                customer1.Age = s.Age;
            }
            db.Entry(customer1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();*/
            //stud.Edit(student);
            int get = _studserv.EditStudent(student);
            return get;
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
          return  _studserv.DeleteStudent(id);
            /*var del = stud.Readkey(id);
            stud.Delete(del);
            stud.SaveChanges();*/
        }
    }
}
