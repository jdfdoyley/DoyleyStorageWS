using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoyleyStorageWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoyleyStorageWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            Dal dal = new Dal();
            return dal.GetAllPeople();
        }
        
        // GET: api/Person/5
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Person
        public void Post([FromBody] Person value)
        {
            Dal dal = new Dal();
            dal.AddPerson(value);
        }
    }
}
