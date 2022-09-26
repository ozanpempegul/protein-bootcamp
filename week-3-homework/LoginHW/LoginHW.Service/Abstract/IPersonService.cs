using LoginHW.Base;
using LoginHW.Data;
using LoginHW.Dto;

namespace LoginHW.Service
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
        Task<PaginationResponse<IEnumerable<PersonDto>>> GetPaginationAsync(QueryResource pagination, PersonDto filterResource);
    }
}
