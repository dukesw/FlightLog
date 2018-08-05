using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System.Collections.Generic;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T Add(T entity);

        void Delete(T entity);

        T GetById(long id);

        T GetSingleBySpec(ISpecification<T> spec);

        IEnumerable<T> List(ISpecification<T> spec);

        IEnumerable<T> ListAll();
        T Update(T entity);
    }
}