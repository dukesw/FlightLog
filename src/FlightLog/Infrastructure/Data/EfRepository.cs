// Copyright DukeSoftware 2018
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : EntityBase
    {
        internal readonly FlightLogContext _dbContext;

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

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public T GetById(long id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
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

        public async Task<List<T>> ListAllAsync(List<Expression<Func<T, object>>> includes)
        {
            var resultsQueryable = includes.Aggregate(_dbContext.Set<T>().AsQueryable(), (current, include) => current.Include(include));
            return await resultsQueryable.ToListAsync();
        }

        public virtual async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // A Queryable for all of the expression based includes
            var resultsQueryableForIncludes = spec.Includes.Aggregate(_dbContext.Set<T>().AsQueryable(), (current, include) => current.Include(include));

            // Add the string based includes
            var resultsQueryableWithAllIncludes = spec.IncludeStrings.Aggregate(resultsQueryableForIncludes, (current, include) => current.Include(include));

            // Finally filter based on the criteria
            return resultsQueryableWithAllIncludes.Where(spec.Criteria).ToListAsync<T>();
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateException dbex)
            {
                return null;
            }
        }
    }
}