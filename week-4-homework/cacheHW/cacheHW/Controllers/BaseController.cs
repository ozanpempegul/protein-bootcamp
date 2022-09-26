using AutoMapper;
using cacheHW.Base;
using Microsoft.AspNetCore.Mvc;

namespace cacheHW
{
    [ApiController]
    public class BaseController<Dto, Entity> : ControllerBase
    {

        private readonly IBaseService<Dto, Entity> _baseService;
        protected readonly IMapper Mapper;


        public BaseController(IBaseService<Dto, Entity> baseService, IMapper mapper)
        {
            this._baseService = baseService;
            this.Mapper = mapper;
        }
    }
}
