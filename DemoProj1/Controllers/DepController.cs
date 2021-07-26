using DemoProj1.Models;
using DemoProj1.Repositry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepController : ControllerBase, ILogger
    {
        private readonly IDepartment Dept;

        public DepController(IDepartment dept)
        {
            this.Dept = dept;
        }

        // GET: api/<DepController>
        [HttpGet]
        public IQueryable<Department> Get()
        {
            return Dept.Read();
        }

        // GET api/<DepController>/5
        [HttpGet("{id}")]
        public IQueryable<Department> Get(int id)
        {
            IQueryable<Department> get = Dept.Readkey(id);
            return get;
        }

        // POST api/<DepController>
        [HttpPost]
        public IQueryable<Department> Post([FromBody] Department depts)
        {
            IQueryable<Department> get = Dept.Add(depts);
            return get;
        }

        // PUT api/<DepController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            /*IEnumerable<Department> get = Dept.Edit(depts);
            return get.ToList();*/
        }

        // DELETE api/<DepController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Dept.Delete(id);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
    }
}
