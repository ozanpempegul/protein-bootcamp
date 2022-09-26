using cacheHW.Base;
using cacheHW.Data;
using cacheHW.Dto;

namespace cacheHW.Service
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
        Task<PaginationResponse<IEnumerable<PersonDto>>> GetPaginationAsync(QueryResource pagination, PersonDto filterResource);
    }
}
