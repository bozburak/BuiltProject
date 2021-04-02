using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);

            await _unitOfWork.CommitAsync();

            return entities;
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public bool Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveRange(IEnumerable<TEntity> entity)
        {
            _repository.RemoveRange(entity);
            _unitOfWork.Commit();
            return true;
        }

        public TEntity Update(TEntity entity)
        {
            var result = _repository.Update(entity);
            _unitOfWork.Commit();
            return result;
        }
    }
}
