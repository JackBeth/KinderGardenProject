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
    public class ToysController : ControllerBase
    {
        private IDataService DataService;

        public ToysController(IDataService s)
        {
            this.DataService = s;
        }

        [HttpGet]
        public List<Toy> Get()
        {
            return DataService.GetToys();
        }

        [HttpPost]
        public async Task<ActionResult<Toy>> AddToyAsync([FromBody] Toy t)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Toy added = await DataService.AddToyAsync(t);
                return Created($"/{added.Name}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete]
        [Route("{Name:String}")]
        public async Task<ActionResult> DeleteToy([FromRoute] string name)
        {
            try
            {
                await DataService.RemoveToyAsync(name);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
