using AutoMapper;
using cacheHW.Data;

namespace cacheHW.Base
{
    public abstract class BaseService<Dto, Entity> : IBaseService<Dto, Entity> where Entity : class
    {

        private readonly IGenericRepository<Entity> baseRepository;
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;


        public BaseService(IGenericRepository<Entity> baseRepository, IMapper mapper, IUnitOfWork unitOfWork) : base()
        {
            this.baseRepository = baseRepository;
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }
    }
}
