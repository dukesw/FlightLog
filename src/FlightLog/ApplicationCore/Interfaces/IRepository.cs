using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System.Collections.Generic;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T Add(T entity);

        void Delete(T entity);

        T GetById(int id);

        T GetSingleBySpec(ISpecification<T> spec);

        IEnumerable<T> GetBySpec(ISpecification<T> spec);

        IEnumerable<T> GetAll();

        T Update(T entity);
    }
}