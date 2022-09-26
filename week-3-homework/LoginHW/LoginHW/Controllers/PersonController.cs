using AutoMapper;
using LoginHW.Base;
using LoginHW.Data;
using LoginHW.Dto;
using LoginHW.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LoginHW
{
    [Route("protein/v1/api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<PersonDto, Person>
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService, IMapper mapper) : base(personService, mapper)
        {
            this.personService = personService;
        }


        [HttpGet]
        public async Task<IActionResult> GetPaginationAsync([FromQuery] int page, [FromQuery] int pageSize)
        {
            Log.Information($"{User.Identity?.Name}: get pagination person.");

            QueryResource pagintation = new QueryResource(page, pageSize);

            var result = await personService.GetPaginationAsync(pagintation, null);

            if (!result.Success)
                return BadRequest(result);

            if (result.Response is null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> GetPaginationWithFilterAsync([FromQuery] int page, [FromQuery] int pageSize, [FromBody] PersonDto filterResource)
        {
            Log.Information($"{User.Identity?.Name}: get pagination person.");

            QueryResource pagintation = new QueryResource(page, pageSize);

            var result = await personService.GetPaginationAsync(pagintation, filterResource);

            if (!result.Success)
                return BadRequest(result);

            if (result.Response is null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public new async Task<IActionResult> GetByIdAsync(int id)
        {            
            Log.Information($"{User.Identity?.Name}: get a person with Id is {id}.");

            return await base.GetByIdAsync(id);
        }

        [HttpPost]
        public new async Task<IActionResult> CreateAsync([FromBody] PersonDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a person.");

            var insertResult = await personService.InsertAsync(resource);

            if (!insertResult.Success)
                return BadRequest(insertResult);

            return StatusCode(201, insertResult);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] PersonDto resource)
        {
            Log.Information($"{User.Identity?.Name}: update a person with Id is {id}.");

            return await base.UpdateAsync(id, resource);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: delete a person with Id is {id}.");

            return await base.DeleteAsync(id);
        }

    }
}
