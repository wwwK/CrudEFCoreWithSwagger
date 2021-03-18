using CrudEFCoreWithSwagger.Context;
using CrudEFCoreWithSwagger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudEFCoreWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CRUDContext _CRUDContext;

        public StudentsController(CRUDContext CRUDContext)
        {
            _CRUDContext = CRUDContext;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _CRUDContext.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _CRUDContext.Students.SingleOrDefault(x => x.StudentId == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _CRUDContext.Students.Add(student);
            _CRUDContext.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Student student)
        {
            _CRUDContext.Students.Update(student);
            _CRUDContext.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CRUDContext.Students.FirstOrDefault(x => x.StudentId == id);
            if (item != null)
            {
                _CRUDContext.Students.Remove(item);
                _CRUDContext.SaveChanges();
            }
        }
    }
}
