using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //constructor is built to inject datacontext here for use in class. 'context parameter is made as private field so class can have access to it.
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            //An ActionResult is a return type of a controller method, also called an action method, and serves as the base class for *Result classes. Action methods return models to views, file streams, redirect to other controllers, or whatever is necessary for the task at hand
            //This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.
            var values = await _context.Values.ToListAsync();
            return Ok(values);  //http 200 ok returns success status response code indicates that request has succeeded.  
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
