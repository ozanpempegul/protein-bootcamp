using AutoMapper;
using cacheHW.Base;
using cacheHW.Data;
using cacheHW.Dto;
using cacheHW.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace cacheHW
{
    [Route("protein/v1/api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<PersonDto, Person>
    {

        private const string employeeListCacheKey = "employeeList";
        private IMemoryCache _cache;
        private readonly IPersonService personService;

        public PersonController(IPersonService personService, IMapper mapper, IMemoryCache cache) : base(personService, mapper)
        {
            this.personService = personService;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        }

        [HttpGet]
        public async Task<IActionResult> GetPaginationAsync([FromQuery] int page, [FromQuery] int pageSize)
        {
            Log.Information($"{User.Identity?.Name}: get pagination person.");

            PaginationResponse<IEnumerable<PersonDto>> result;

            if (_cache.TryGetValue(employeeListCacheKey, out result))
            {                
            }

            else
            {
                QueryResource pagination = new QueryResource(page, pageSize);

                result = await personService.GetPaginationAsync(pagination, null);

                if (!result.Success)
                    return BadRequest(result);

                if (result.Response is null)
                    return NoContent();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);

                _cache.Set(employeeListCacheKey, result, cacheEntryOptions);
            }


            return Ok(result);
        }
    }
}
