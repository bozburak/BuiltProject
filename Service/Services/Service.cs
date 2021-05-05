using Core.Aspects.AspectInjector.Logging;
using Core.Aspects.AspectInjector.Caching.Triggers;
using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.AutoMapper;
using System.Linq;

namespace Service.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TDto> AddAsync(TDto entity)
        {
            await _repository.AddAsync(ObjectMapper.Mapper.Map<TEntity>(entity));

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<IEnumerable<TDto>> AddRangeAsync(IEnumerable<TDto> entities)
        {
            await _repository.AddRangeAsync(ObjectMapper.Mapper.Map<IEnumerable<TEntity>>(entities));

            await _unitOfWork.CommitAsync();

            return entities;
        }

        public IEnumerable<TDto> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _repository.Where(predicate);
            return ObjectMapper.Mapper.Map<IEnumerable<TDto>>(result);
        }

        [LogAspect]
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<TDto>>(result);
        }

        public async Task<TDto> GetByIdAsync(string id)
        {
            var result = await _repository.GetByIdAsync(id);
            return ObjectMapper.Mapper.Map<TDto>(result);
        }

        public bool Remove(string id)
        {
            var isExist  = _repository.GetByIdAsync(id).Result;

            _repository.Remove(isExist);

            _unitOfWork.Commit();

            return true;
        }

        public bool RemoveRange(IEnumerable<string> ids)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (var id in ids)
            {
                var isExist = _repository.GetByIdAsync(id).Result;
                entities.Add(isExist);
            }
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
            return true;
        }

        public void Update(TDto entity)
        {
            _repository.Update(ObjectMapper.Mapper.Map<TEntity>(entity));
            _unitOfWork.Commit();
        }
    }
}
