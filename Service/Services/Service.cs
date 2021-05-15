using Core.Aspects.AspectInjector.Logging;
using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.AutoMapper;
using Core.Utilities.Results;

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

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            await _repository.AddAsync(ObjectMapper.Mapper.Map<TEntity>(entity));

            await _unitOfWork.CommitAsync();

            return Response<TDto>.Success(entity, 200);
        }

        public async Task<Response<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> entities)
        {
            await _repository.AddRangeAsync(ObjectMapper.Mapper.Map<IEnumerable<TEntity>>(entities));

            await _unitOfWork.CommitAsync();

            return Response<IEnumerable<TDto>>.Success(entities, 200);
        }

        public Response<IEnumerable<TDto>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _repository.Where(predicate);
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(result), 200);
        }

        [LogAspect]
        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(result), 200);
        }

        public async Task<Response<TDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(result), 200);
        }

        public Response<NoContent> Remove(long id)
        {
            var isExist  = _repository.GetByIdAsync(id).Result;

            _repository.Remove(isExist);

            _unitOfWork.Commit();

            return Response<NoContent>.Success(204);
        }

        public Response<NoContent> RemoveRange(IEnumerable<long> ids)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (var id in ids)
            {
                var isExist = _repository.GetByIdAsync(id).Result;
                entities.Add(isExist);
            }
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
            return Response<NoContent>.Success(204);
        }

        public Response<NoContent> Update(TDto entity)
        {
            _repository.Update(ObjectMapper.Mapper.Map<TEntity>(entity));
            _unitOfWork.Commit();
            return Response<NoContent>.Success(204);
        }
    }
}
