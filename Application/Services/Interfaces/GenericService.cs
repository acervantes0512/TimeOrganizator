using Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.GetGenericRepository<T>().GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.GetGenericRepository<T>().GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.GetGenericRepository<T>().DeleteAsync(id);
            _unitOfWork.SaveChanges();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            T UpdatedEntity = await _unitOfWork.GetGenericRepository<T>().UpdateAsync(entity);
            _unitOfWork.SaveChanges();
            return UpdatedEntity;

        }

        public async Task<T> CreateAsync(T entity)
        {
            T createdEntity = await _unitOfWork.GetGenericRepository<T>().AddAsync(entity);
            _unitOfWork.SaveChanges();
            return createdEntity;
        }
    }
}
