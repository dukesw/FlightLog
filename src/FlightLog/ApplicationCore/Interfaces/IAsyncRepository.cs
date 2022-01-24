using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
      //  Task<List<T>> ListAllAsync(List<Expression<Func<T, object>>> includes);
        Task<List<T>> GetBySpecAsync(ISpecification<T> spec);
        Task<int> GetCountBySpecAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
