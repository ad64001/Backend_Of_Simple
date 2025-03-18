using AutoMapper;
using Backend.IServices;
using Backend.Model;
using Backend.Repository;
using Backend.Repository.Base;

namespace Backend.Services
{
    public class BaseService<AEntity,AVo> : IBaseService<AEntity, AVo> where AEntity : class, new()
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<AEntity> _baseRepository;

        public BaseService(IMapper mapper,IBaseRepository<AEntity> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<AVo>> Query()
        {
            var entities = await _baseRepository.Query();
            var outc = _mapper.Map<List<AVo>>(entities);
            return outc;
        }
    }
}
