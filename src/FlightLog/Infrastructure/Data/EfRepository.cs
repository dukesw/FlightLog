// Copyright DukeSoftware 2018 $(file)
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly FlightLogContext _dbContext;

        public EfRepository(FlightLogContext context)
        {
            _dbContext = context;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(long id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            // A Queryable for all of the expression based includes
            var resultsQueryableForIncludes = spec.Includes.Aggregate(_dbContext.Set<T>().AsQueryable(), (current, include) => current.Include(include));

            // Add the string based includes
            var resultsQueryableWithAllIncludes = spec.IncludeStrings.Aggregate(resultsQueryableForIncludes, (current, include) => current.Include(include));

            // Finally filter based on the criteria
            return resultsQueryableWithAllIncludes.Where(spec.Criteria).AsEnumerable<T>();

        }

        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}