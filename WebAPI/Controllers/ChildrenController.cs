using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private IDataService DataService;

        public ChildrenController(IDataService s)
        {
            this.DataService = s;
        }

        // GET: api/<ChildrenController>
        [HttpGet]
        public List<Child> Get()
        {
            return DataService.GetChildren();
        }

        [HttpPost]
        public async Task<ActionResult<Child>> AddChildAsync([FromBody] Child c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Child added = await DataService.AddChildAsync(c);
                return Created($"/{added.Age}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}