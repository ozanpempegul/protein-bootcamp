using AutoMapper;
using cacheHW.Base;
using cacheHW.Data;
using cacheHW.Dto;

namespace cacheHW.Service
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        public PersonService(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(personRepository, mapper, unitOfWork)
        {
            this.personRepository = personRepository;
        }

        private readonly IPersonRepository personRepository;


        public async Task<PaginationResponse<IEnumerable<PersonDto>>> GetPaginationAsync(QueryResource pagination, PersonDto filterResource)
        {
            var paginationPerson = await personRepository.GetPaginationAsync(pagination, filterResource);

            // Mapping
            var tempResource = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(paginationPerson.records);

            var resource = new PaginationResponse<IEnumerable<PersonDto>>(tempResource);

            // Using extension-method for pagination
            resource.CreatePaginationResponse(pagination, paginationPerson.total);

            return resource;
        }


    }
}
