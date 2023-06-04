using AutoMapper;
using AutoMapper.QueryableExtensions;
using TelephoneDirectory.Report.Service.Services.Bases.Interfaces;
using TelephoneDirectory.Framework.Repository.Repositories.Interfaces;

namespace TelephoneDirectory.Report.Service.Services.Bases
{
    public abstract class Service<TRepository, TEntity> : IService where TRepository : IRepository<TEntity> where TEntity : class
    {
        protected readonly TRepository Repository;
        protected readonly IMapper _mapper;

        public Service(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async virtual Task<TResponseDto> AddAsync<TRequestDto, TResponseDto>(TRequestDto model) where TRequestDto : class, new()
        {
            var entity = _mapper.Map<TEntity>(model);
            entity = await Repository.AddAsync(entity);

            return _mapper.Map<TResponseDto>(entity);
        }

        public async virtual Task<TResponseDto> UpdateAsync<TRequestDto, TResponseDto>(object id, TRequestDto model) where TRequestDto : class, new()
        {
            var entity = await Repository.GetByIdAsync(id);
            entity = _mapper.Map(model, entity);
            await Repository.UpdateAsync(id, entity);

            return _mapper.Map<TResponseDto>(entity);
        }

        public async virtual Task DeleteAsync(object id)
        {
            await Repository.DeleteAsync(id);
        }

        public async virtual Task<IEnumerable<TResponseDto>> GetAllAsync<TResponseDto>()
        {
            var entities = Repository.Queryable.ProjectTo<TResponseDto>(_mapper.ConfigurationProvider).ToList();
            return entities;
        }

        public async virtual Task<TResponseDto> GetByIdAsync<TResponseDto>(object id)
        {
            var entity = await Repository.GetByIdAsync(id);
            return _mapper.Map<TResponseDto>(entity);
        }
    }
}
